using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class DishInventoryUI : MonoBehaviour
{
   // private DishInventoryManager dishInventoryManager;
    public GameObject dishPrefab;
    public Transform content;
    public Button serveButton;

    [SerializeField]
    private TextMeshProUGUI selectedDishInfoText;
    
   // public delegate void ServeDishEvent(Dish dish);
   //  public ServeDishEvent OnServeDish;

    private Dish selectedDish;


    private void Awake()
    {
        GameManager.Instance.DishInventoryManager.DishInventoryUI = this;
        GameManager.Instance.DishInventoryManager.ToggleDishUI();
        
        serveButton.onClick.AddListener(delegate {
        {
            ServeDish();
            gameObject.SetActive(false);
        } });
        
    }

    private void OnEnable()
    {
        serveButton.interactable = false;
        LoadInventory();
    }

    public void LoadInventory()
    {
       content.transform.DestroyAllChildren();
      //foreach (Transform item in content)  Destroy(item.gameObject);
      
        foreach (Dish dish in GameManager.Instance.DishInventoryManager.dishInventory)
        {
            GameObject dishObject = Instantiate(dishPrefab, content);
            DishItemUI dishItemUI = dishObject.GetComponent<DishItemUI>();
            dishItemUI.Setup(dish);
            dishItemUI.OnSelectDishEvent += SelectDish;
           // dishItemUI.OnDeselectDishEvent += DeselectDish;
        }
    }
    public void DeselectDish()
    {
        
        selectedDish = null;
        serveButton.interactable = false;
        selectedDishInfoText.text = "NO DISH SELECTED!";
    }
    public void SelectDish(Dish dish)
    {
        
        selectedDish = dish;
        selectedDishInfoText.text = selectedDish.Name;
        serveButton.interactable = true;
    }
    public void UnselectDish()
    {
        selectedDish = null;
        serveButton.interactable = false;
    }
    public void ServeDish()
    {
     //   OnServeDish?.Invoke(selectedDish);
        GameManager.Instance.ProcessDish(selectedDish);
        GameManager.Instance.DishInventoryManager.RemoveDish(selectedDish);
        selectedDish = null;
        DeselectDish();
        serveButton.interactable = false;
      
    }
}
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class DishInventoryUI : MonoBehaviour
{
    public DishInventoryManager dishInventoryManager;
    public GameObject dishPrefab;
    public Transform content;
    public Button serveButton;

    public delegate void ServeDishEvent(Dish dish);
    public ServeDishEvent OnServeDish;

    private Dish selectedDish;


    private void Awake()
    {
         
        dishInventoryManager ??= GameManager.Instance.DishInventoryManager;
        serveButton.onClick.AddListener(delegate { ServeDish(); });
        
    }

    private void Start()
    {
        serveButton.interactable = false;
        LoadInventory();
    }

    public void LoadInventory()
    {
        content.DestroyAllChildren();
        foreach (Dish dish in dishInventoryManager.dishInventory)
        {
            GameObject dishObject = Instantiate(dishPrefab, content);
            DishItemUI dishItemUI = dishObject.GetComponent<DishItemUI>();
            dishItemUI.Setup(dish);
            dishItemUI.OnSelectDishEvent += SelectDish;
        }
    }

    public void SelectDish(Dish dish)
    {
        selectedDish = dish;
        serveButton.interactable = true;
    }

    public void ServeDish()
    {
        OnServeDish?.Invoke(selectedDish);
        dishInventoryManager.dishInventory.Remove(selectedDish);
        selectedDish = null;
        serveButton.interactable = false;
    }
}
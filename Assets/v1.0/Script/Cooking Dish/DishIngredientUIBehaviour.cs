using System;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class DishIngredientUIBehaviour : MonoBehaviour, IDropHandler
{
    
[ReadOnly] public bool IsInitialized;
    public Dictionary<FoodItem, int> FoodItemWithAmount = new Dictionary<FoodItem, int>();
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI count;
    [SerializeField] private GameObject buttonContainer;
    [SerializeField] private Button increaseAmountBtn;
    [SerializeField] private Button decreaseAmountBtn;
    private FoodItem _foodItem;
    private void Awake()
    {
        increaseAmountBtn.onClick.AddListener(IncreaseAmount);
        decreaseAmountBtn.onClick.AddListener(DecreaseAmount);
    }

    public void IncreaseAmount()
    {
        // TODO : Dry principal broken
        FoodItemWithAmount[_foodItem] += GameManager.Instance.InventoryManager.RemoveFoodItem(_foodItem, 1);
        count.text = FoodItemWithAmount[_foodItem].ToString();
        
    }
    public void DecreaseAmount()
    {
        FoodItemWithAmount[_foodItem] -=  GameManager.Instance.InventoryManager.AddFoodItem(_foodItem, 1);
        count.text = FoodItemWithAmount[_foodItem].ToString();
       
        if (FoodItemWithAmount[_foodItem] <= 0)
        {
            Reset();
        }
    }
    public void Setup(FoodItem foodItem)
    {
        _foodItem = foodItem;
        FoodItemWithAmount[foodItem] = 1;
        GameManager.Instance.InventoryManager.RemoveFoodItem(DragableItem.Instance.FoodItem, 1);
        itemName.text = foodItem.foodName;
        count.text = FoodItemWithAmount[foodItem].ToString();
        buttonContainer.SetActive(true);
        IsInitialized = true;
    }

    public void Reset()
    {
        IsInitialized = false;
        FoodItemWithAmount = new Dictionary<FoodItem, int>();
        itemName.text = count.text = "";
        buttonContainer.SetActive(false);
        
    }
    public void OnDrop(PointerEventData eventData)
    {
        DragableItem.Instance.canvasGroup.alpha = 0;
     //   RectTransform itemBeingDragged = eventData.pointerDrag.GetComponent<RectTransform>();
       // itemBeingDragged.SetParent(transform);
        // itemBeingDragged.localPosition = Vector3.zero;
     //   itemBeingDragged.anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
     
     if (DragableItem.Instance.FoodItem == null) return;
     if (!IsInitialized)
     {
         Setup(DragableItem.Instance.FoodItem);
     }
     else
     {
         IncreaseAmount();
     }

    // CookingManager.Instance.DishInfoUI.Setup(CookingManager.Instance.DishUIBehaviour.PredictDish(),false);

     //  Debug.Log($" Droped!");
    }
}

 
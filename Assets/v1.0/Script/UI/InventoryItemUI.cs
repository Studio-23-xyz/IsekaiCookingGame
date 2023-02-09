using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using UnityEngine.EventSystems;

public class InventoryItemUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Button itemButton;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemCount;

    public FoodItem FoodItem;

    [SerializeField] private CanvasGroup canvasGroup;

    private void Awake()
    {
        itemButton.onClick.AddListener(delegate
        {
            CookingManager.Instance.DishUIBehaviour.ShowItemInfo(new KeyValuePair<FoodItem, int>(FoodItem, 0)); 
        });
    }

    public void Setup(KeyValuePair<FoodItem, int> item)
    {
        this.FoodItem = item.Key;
        itemName.text = FoodItem.foodName;
        itemCount.text = item.Value.ToString();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0;
        DragableItem.Instance.Setup(FoodItem, eventData);
        DragableItem.Instance.OnBeginDrag(eventData);
        CookingManager.Instance.DishUIBehaviour.ShowItemInfo(new KeyValuePair<FoodItem, int>(FoodItem, 0));  
    }
    public void OnDrag(PointerEventData eventData)
    {
     //  Debug.Log($"OnDrag!");
       DragableItem.Instance.OnDrag(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1;
        DragableItem.Instance.OnEndDrag(eventData);
       // Debug.Log($"OnEndDrag!");
    }
}
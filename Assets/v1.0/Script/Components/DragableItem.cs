using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragableItem : MonoBehaviour
{
    public static DragableItem Instance;
    
    public TextMeshProUGUI itemName;
    public CanvasGroup canvasGroup;

    public FoodItem FoodItem;

    public RectTransform rectTransform;
    
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else
        {
             Destroy( gameObject);
        }
    }

    public void Setup(FoodItem foodItem, PointerEventData eventData)
    {
        this.FoodItem = foodItem;
        itemName.text = foodItem.foodName;
        
    }

    
    public void OnBeginDrag(PointerEventData eventData)
    {
      //  Debug.Log($"OnBeginDrag!");
        transform.position = Input.mousePosition;
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
       // Debug.Log($"OnDrag!");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
       // Debug.Log($"OnEndDrag!");
        canvasGroup.alpha = 0;
    }
}

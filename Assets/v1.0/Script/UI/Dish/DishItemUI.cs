using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DishItemUI : MonoBehaviour
{
    public TextMeshProUGUI dishNameText;
    public TextMeshProUGUI dishPriceText;
    
    
    
    private Dish _dish;
    private Button _button;
    public delegate void SelectDishEvent(Dish dish);
    public SelectDishEvent OnSelectDishEvent;

   private void Awake()
   {
       _button = GetComponent<Button>();
       _button.onClick.AddListener(delegate { OnSelectDishEvent.Invoke(_dish); });
   }

   public void Setup(Dish dish)
   {
       _dish = dish;
        dishNameText.text = dish.Name;
        dishPriceText.text = "$" + dish.BasePrice.ToString();
    }
    
}
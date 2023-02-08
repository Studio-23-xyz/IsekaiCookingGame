using System;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;



public class DishIngredientUIBehaviour : MonoBehaviour
{
     
    
    
    public Dictionary<FoodItem, int> FoodItemWithAmount = new Dictionary<FoodItem, int>();
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI count;

    public void Setup(FoodItem foodItem)
    {
        FoodItemWithAmount[foodItem] = 1;
        itemName.text = foodItem.foodName;
        count.text = FoodItemWithAmount[foodItem].ToString();
    }
}

 
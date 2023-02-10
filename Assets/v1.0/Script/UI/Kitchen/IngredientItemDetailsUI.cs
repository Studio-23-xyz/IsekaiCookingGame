using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class IngredientItemDetailsUI : MonoBehaviour
{
    
    
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemCategory;
    public TextMeshProUGUI itemWeight;
    public TextMeshProUGUI itemFlavor;
    public TextMeshProUGUI itemPrice;

    private FoodItem FoodItem;

    
  

    public void Setup(KeyValuePair<FoodItem, int> item)
    {
        this.FoodItem = item.Key;
        itemName.text = $"Name : {FoodItem.foodName}<br>Quantity : {item.Value.ToString()}";
        itemCategory.text = $"Category : {FoodItem.category.ToString()}";
        itemWeight.text = $"Weight : gm{FoodItem.weight.ToString()}";
        itemFlavor.text = $"Flavor : {FoodItem.flavorValue.ToString()}";
        itemPrice.text = $"Price : ${FoodItem.price.ToString()}";
       
    }
   
}
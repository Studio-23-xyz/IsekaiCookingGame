using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DishInfoUI : MonoBehaviour
{

    public Image bg;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemCategory;
    public TextMeshProUGUI itemWeight;
    public TextMeshProUGUI itemFlavor;
    public TextMeshProUGUI itemPrice;

    public void Setup(Dish item, bool isCooked)
    {
       
        itemName.text = $"Name : {item.Name}";
        
        itemCategory.text = $"Category : {item.Categories.ToArray()}";
      
        itemWeight.text = $"Weight : gm{item.Weight.ToString()}";
        itemFlavor.text = $"Flavor : {item.Flavors.ToArray()}";
        itemPrice.text = $"Price : ${item.BasePrice.ToString()}";

        bg.color = isCooked ? Color.green : Color.gray;
    }
   
}
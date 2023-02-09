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

    public void Setup(Dish item, Color color)
    {
       
        itemName.text = $"Name : {item.Name}";
        
        itemCategory.text = $"Category : {string.Join(", ", item.Categories)}";
      
        itemWeight.text = $"Weight : gm{item.Weight.ToString()}";
        itemFlavor.text = $"Flavor : {string.Join("<br>", item.Flavors)}";
        itemPrice.text = $"Price : ${item.BasePrice.ToString()}";

        bg.color = color;
    }
    public void Reset()
    {
        itemName.text =
            itemCategory.text =
                itemWeight.text =
                    itemFlavor.text =
                        itemPrice.text = "";

            bg.color = Color.gray;
    }
}
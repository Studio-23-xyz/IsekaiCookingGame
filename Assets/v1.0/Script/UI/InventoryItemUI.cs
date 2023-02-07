using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class InventoryItemUI : MonoBehaviour
{
    public Button itemButton;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemCount;

    public FoodItem Item;


    private void Start()
    {
 
        itemButton.onClick.AddListener(HandleClick);
    }

    public void Setup(KeyValuePair<FoodItem, int> item)
    {
        this.Item = item.Key;
        itemName.text = Item.foodName;
        itemCount.text = item.Value.ToString();
    }

    private void HandleClick()
    {
        // Fire an event with the food item data
       
    }
}
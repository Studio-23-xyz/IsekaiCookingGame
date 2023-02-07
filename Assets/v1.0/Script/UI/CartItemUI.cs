using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CartItemUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI foodNameText;
    [SerializeField] private TextMeshProUGUI foodCountText;
    [SerializeField] private TextMeshProUGUI foodPriceText;


    
    public void Setup(KeyValuePair<FoodItem, int> item)
    {
        foodNameText.text = item.Key.foodName;
        foodCountText.text = item.Value.ToString();
        foodPriceText.text = (item.Key.price * item.Value).ToString();
    }
    
}
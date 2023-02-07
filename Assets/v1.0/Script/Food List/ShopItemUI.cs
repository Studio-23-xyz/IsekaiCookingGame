using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemUI : MonoBehaviour
{
   [SerializeField] private FoodItem foodItem;
   [SerializeField]private TextMeshProUGUI foodNameText;
   [SerializeField] private TextMeshProUGUI categoryText;
   [SerializeField] private TextMeshProUGUI flavorText;
   [SerializeField] private TextMeshProUGUI priceText;

   [SerializeField] private Button button;
    public delegate void FoodItemUIClick(FoodItem foodItem);

    public FoodItemUIClick OnFoodItemClick;

    private void Awake()
    {
        button.onClick.AddListener(delegate { OnFoodItemClick?.Invoke(foodItem); });
    }

    public void LoadFoodDisplay(FoodItem foodItem)
    {
        this.foodItem = foodItem;
        foodNameText.text = foodItem.foodName;
        categoryText.text = foodItem.category.ToString();
        flavorText.text = foodItem.flavorValue.Name.ToString();
        priceText.text = foodItem.price.ToString();
    }

   

}
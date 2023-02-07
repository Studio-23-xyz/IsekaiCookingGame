using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FoodDisplay : MonoBehaviour
{
    public FoodItem foodItem;
    public TextMeshProUGUI foodNameText;
    public TextMeshProUGUI categoryText;
    public TextMeshProUGUI flavorText;
    public TextMeshProUGUI priceText;

    public void LoadFoodDisplay(FoodItem foodItem)
    {
        this.foodItem = foodItem;
        foodNameText.text = foodItem.foodName;
        categoryText.text = foodItem.category.ToString();
        flavorText.text = foodItem.flavorValue.Name.ToString();
        priceText.text = foodItem.price.ToString();
    }
}
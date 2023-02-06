using UnityEngine;
using UnityEngine.UI;

public class FoodDisplay : MonoBehaviour
{
    public FoodItem foodItem;
    public Text foodNameText;
    public Text categoryText;
    public Text flavorText;
    public Text priceText;

    public void LoadFoodDisplay(FoodItem foodItem)
    {
        this.foodItem = foodItem;
        foodNameText.text = foodItem.name;
        categoryText.text = foodItem.category.ToString();
        flavorText.text = foodItem.flavorValue.Name.ToString();
        priceText.text = foodItem.price.ToString();
    }
}
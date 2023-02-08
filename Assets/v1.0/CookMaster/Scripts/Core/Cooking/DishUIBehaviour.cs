using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DishUIBehaviour : MonoBehaviour
{
    public DishIngredientUIBehaviour primaryIngredient;
    public DishIngredientUIBehaviour secondaryIngredient;
    public List<DishIngredientUIBehaviour> optionalIngredients;

    private Dish dish;

    public void Cook()
    {
        dish = new Dish();

        AddIngredientsToDish();
        dish.Cook();
    }

    private void AddIngredientsToDish()
    {
        dish.FoodItems = new Dictionary<FoodItem, int>();
        AddIngredientToDish(primaryIngredient);
        AddIngredientToDish(secondaryIngredient);
        foreach (var ingredient in optionalIngredients)
        {
            AddIngredientToDish(ingredient);
        }
    }

    private void AddIngredientToDish(DishIngredientUIBehaviour ingredient)
    {
       FoodItem foodItem = ingredient.FoodItemWithAmount.Keys.First();
       int  count = ingredient.FoodItemWithAmount[foodItem];
       dish.FoodItems[foodItem] += count;
    }
}
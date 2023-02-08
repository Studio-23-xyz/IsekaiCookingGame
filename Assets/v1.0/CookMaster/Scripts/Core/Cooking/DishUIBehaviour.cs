using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DishUIBehaviour : MonoBehaviour
{
    public DishIngredientUIBehaviour primaryIngredient;
    public DishIngredientUIBehaviour secondaryIngredient;
    public List<DishIngredientUIBehaviour> optionalIngredients;

    [SerializeField]private Dish dish;
    [SerializeField] private Button cookButton;
    private void Awake()
    {
        cookButton.onClick.AddListener(Cook);
    }

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
       if (dish.FoodItems.ContainsKey(foodItem))
       {
           dish.FoodItems[foodItem] += count;
       }
       else
       {
           dish.FoodItems.Add(foodItem, 1);
       }
       
    }
}
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


    public DishInfoUI DishInfoUI;
    private void Awake()
    {
        cookButton.onClick.AddListener(delegate
        {

            if (Cook())
            {
                ClearIngredients();
                GameManager.Instance.DishInventoryManager.AddDish(dish);
               
                DishInfoUI.Setup(dish, new Color(.52f, 1, .52f,1));
            }
            else
            {
               DishInfoUI.Reset();
            }
            
            
        });
       
    }

  
    private bool Cook()
    {
        dish = new Dish();
        if (AddIngredientsToDish())
        {
            dish.Cook();
            return true;
        }
        else return false;
    }

   /* public Dish PredictDish()
    {
        return dish.PredictCook();
    }*/

    private bool AddIngredientsToDish()
    {
        if (primaryIngredient.IsInitialized && secondaryIngredient.IsInitialized)
        {
            dish.FoodItems = new Dictionary<FoodItem, int>();
            AddIngredientToDish(primaryIngredient);
            AddIngredientToDish(secondaryIngredient);
            foreach (var ingredient in optionalIngredients)
            {
                AddIngredientToDish(ingredient);
            }
            return  true;
        }else  return false;
    }

    public void ClearIngredients()
    {
        if (primaryIngredient.IsInitialized) primaryIngredient.Reset();
        if (secondaryIngredient.IsInitialized) secondaryIngredient.Reset();
        foreach (var ingredient in optionalIngredients)
        {
            if (ingredient.IsInitialized) ingredient.Reset();
        }
    }
    private void AddIngredientToDish(DishIngredientUIBehaviour ingredient)
    {
        if(!ingredient.IsInitialized) return;
        
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
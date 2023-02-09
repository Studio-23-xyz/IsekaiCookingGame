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

    [SerializeField] private IngredientItemDetailsUI _ingredientItemDetailsUI;
    [SerializeField] private DishInfoUI _dishInfoUI;
    private void Awake()
    {
        cookButton.onClick.AddListener(delegate { Cook(true); });
        if (_ingredientItemDetailsUI == null) _ingredientItemDetailsUI = transform.GetComponentInChildren<IngredientItemDetailsUI>();
        if (_dishInfoUI == null) _dishInfoUI = transform.GetComponentInChildren<DishInfoUI>();
    }

   /// <summary>
   /// 
   /// </summary>
   /// <param name="IsRealCook"> is true when try to cook else false, its use to show data on ui</param>
    public void Cook(bool IsRealCook)
    {
        if (ProcessCooking())
        {
            if(_dishInfoUI) _dishInfoUI.Setup(dish, IsRealCook);
        }
    }
    
    public bool ProcessCooking()
    {
        dish = new Dish();
        if (AddIngredientsToDish())
        {
            dish.Cook();
            return true;
        }
        else return false;
    }

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

    public void ShowItemInfo(KeyValuePair<FoodItem, int> item)
    {
        if(_ingredientItemDetailsUI) _ingredientItemDetailsUI.Setup(new KeyValuePair<FoodItem, int>(item.Key, item.Value));
    }
   
}
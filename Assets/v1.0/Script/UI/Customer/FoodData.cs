using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FoodData
{
    public List<DishPreference> DishPreferences;
    
    
    private DishPreference SelectedDishPreference;
    
    
    public void GenerateRandomDishPreferences()
    {
        int numberOfDishPreferences = UnityEngine.Random.Range(2, 6);
        DishPreferences = new List<DishPreference>();
        for (int i = 0; i < numberOfDishPreferences; i++)
        {
            DishPreferences.Add(new DishPreference((FoodCategory)UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(FoodCategory)).Length), (Flavortype)Random.Range(0, System.Enum.GetValues(typeof(Flavortype)).Length)));
        }
    }

    public DishPreference RequestDish()
    {
        int randomIndex = UnityEngine.Random.Range(0, DishPreferences.Count);
        SelectedDishPreference= DishPreferences[randomIndex];
        return SelectedDishPreference;
    }

    public bool EvaluateDish(Dish dish)
    {
        return dish.Categories.Contains(SelectedDishPreference.Category) && dish.Flavors.Exists(f => f.Name == SelectedDishPreference.Flavor);
    }


}

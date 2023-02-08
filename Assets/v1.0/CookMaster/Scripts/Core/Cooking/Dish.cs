using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class Dish
{
    public Dictionary<FoodItem, int> FoodItems;
    public float Weight;
    public List<Flavor> Flavors;
    public List<FoodCategory> Categories;
    public float BasePrice;
    [TextArea]
    public string Name;

    [ContextMenu("Cook")]
    public void Cook()
    {
        CalculateWeight();
        CalculateFlavors();
        CalculateCategories();
        CalculateBasePrice();
        Name = GetDishName();
    }

    private void CalculateWeight()
    {
        Weight = FoodItems.Sum(item => item.Key.weight * item.Value);
    }

    private void CalculateFlavors()
    {
        var flavorsGroupedByName = FoodItems.Select(foodItem => 
            {
                for (int i = 0; i < foodItem.Value; i++)
                {
                    return foodItem.Key.flavorValue;
                }
                return null;
            }).Where(x => x != null)
            .GroupBy(flavor => flavor.Name)
            .Select(group => new Flavor
            {
                Name = group.Key,
                Value = group.Sum(flavor => flavor.Value)
            });
        Flavors = flavorsGroupedByName.ToList();
    }

    private void CalculateCategories()
    {
        Categories = FoodItems.Select(item => item.Key.category)
            .Distinct()
            .ToList();
    }

    private void CalculateBasePrice()
    {
        BasePrice = FoodItems.Sum(item => item.Key.price * item.Value);
    }

    private string GetDishName()
    {
        Flavor primaryFlavor = Flavors.OrderByDescending(flavor => flavor.Value).First();
        FoodItem mainIngredient = FoodItems.First().Key;
        string dishName = $"{primaryFlavor.Name} {mainIngredient.foodName}";
        return dishName;
    }
}
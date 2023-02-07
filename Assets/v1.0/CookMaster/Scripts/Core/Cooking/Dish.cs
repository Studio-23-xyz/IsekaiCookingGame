using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Dish : MonoBehaviour
{
    public List<FoodItem> foodItems;
    public float weight;
    public List<Flavor> flavors;
    public List<FoodCategory> categories;
    public float basePrice;
    [TextArea]
    public string name;

    [ContextMenu("Cook")]
    public void Cook()
    {
        CalculateWeight();
        CalculateFlavors();
        CalculateCategories();
        CalculateBasePrice();
        name = GetDishName();
    }

    private void CalculateWeight()
    {
        weight = foodItems.Sum(foodItem => foodItem.weight);
    }

    private void CalculateFlavors()
    {
        var flavorsGroupedByName = foodItems.Select(foodItem => foodItem.flavorValue)
            .GroupBy(flavor => flavor.Name)
            .Select(group => new Flavor
            {
                Name = group.Key,
                Value = group.Sum(flavor => flavor.Value)
            });
        flavors = flavorsGroupedByName.ToList();
    }

    private void CalculateCategories()
    {
        categories = foodItems.Select(foodItem => foodItem.category)
            .Distinct()
            .ToList();
    }

    private void CalculateBasePrice()
    {
        basePrice = foodItems.Sum(foodItem => foodItem.price);
    }

    private string GetDishName()
    {
        Flavor primaryFlavor = flavors.OrderByDescending(flavor => flavor.Value).First();
        string dishName = $"{primaryFlavor.Name} {foodItems[0].foodName} with {foodItems[1].foodName}";
        return dishName;
    }
}

using System;
using System.Linq;
using UnityEngine;

[Serializable]
public class DishPreference
{
    public FoodCategory Category;
    public Flavortype Flavor;

    public DishPreference(FoodCategory category, Flavortype flavor)
    {
        Category = category;
        Flavor = flavor;
    }
    public override string ToString()
    {
        return $"{Flavor.ToString()} {Category.ToString()}";
    }

    public static DishPreference CreateRandom()
    {
        DishPreference dishPreference = new DishPreference((FoodCategory)UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(FoodCategory)).Length), (Flavortype)UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(Flavortype)).Length));
        return dishPreference;
        
        
    }
    
    public bool CheckFlavorMatch(Dish dish)
    {
        Flavor primaryFlavor = dish.Flavors.OrderByDescending(flavor => flavor.Value).First();
        Flavortype primaryFlavorType = (Flavortype)Enum.Parse(typeof(Flavortype), primaryFlavor.Name.ToString());
        return primaryFlavorType == Flavor   && dish.Categories.Contains(Category);
       
    }
    
}

using System;

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


}

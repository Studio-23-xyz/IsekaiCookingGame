using UnityEngine;

[CreateAssetMenu(menuName = "Food Item")]
public class FoodItem : ScriptableObject
{
    public float weight;
    public string foodName;
    public float price;
    public FoodCategory category;
    public Flavor flavorValue;

    public static FoodItem[] FromCSV(string csv)
    {
        string[] lines = csv.Split('\n');
        int numItems = lines.Length - 1;
        FoodItem[] foodItems = new FoodItem[numItems-1];

        for (int i = 1; i < numItems; i++)
        {
            string[] fields = lines[i].Split(',');
            foodItems[i - 1] = new FoodItem
            {
                weight = float.Parse(fields[1]),
                foodName = fields[0],
                price = float.Parse(fields[2]),
                category = (FoodCategory)System.Enum.Parse(typeof(FoodCategory), fields[3]),
                flavorValue = new Flavor
                {
                    Name = (Flavortype)System.Enum.Parse(typeof(Flavortype), fields[4]),
                    Value = int.Parse(fields[5])
                }
            };
        }
        return foodItems;
    }




}

[System.Serializable]
public class Flavor
{
    public Flavortype Name;
    public int Value;
}

public enum Flavortype
{
    Umami,
    Sour,
    Sweet,
    Salty,
    Bitter,
    Spicy
}

public enum FoodCategory
{
    Meat,
    Fish,
    Vegetable,
    Ingredient,
    Dairy,
    Grains,
    Fruit
}

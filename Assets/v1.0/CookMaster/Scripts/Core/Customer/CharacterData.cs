using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "ScriptableObjects/CharacterData")]
public class CharacterData : ScriptableObject
{
    public string Name;
    public string Race;
    public string Occupation;
    public string Backstory;
    public List<DishPreference> DishPreferences = new List<DishPreference>();

    public void CreateRandomDishPreferences(int count)
    {
        DishPreferences.Clear();

        for (int i = 0; i < count; i++)
        {
            DishPreferences.Add(DishPreference.CreateRandom());
        }
    }
}
/*
[System.Serializable]
public class DishPreference
{
    public FoodCategory FoodCategory;
    public FlavorPreference FlavorPreference;

    public static DishPreference CreateRandom()
    {
        DishPreference dishPreference = new DishPreference();
        dishPreference.FoodCategory = (FoodCategory)Random.Range(0, System.Enum.GetValues(typeof(FoodCategory)).Length);
        dishPreference.FlavorPreference = (FlavorPreference)Random.Range(0, System.Enum.GetValues(typeof(FlavorPreference)).Length);
        return dishPreference;
    }
}*/
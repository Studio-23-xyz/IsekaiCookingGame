using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "ScriptableObjects/CharacterData")]
public class CharacterData : ScriptableObject
{
    public string Name;
    public string Race;
    public string Occupation;
    [TextArea(30,500)]
    public string Backstory;
    public List<DishPreference> DishPreferences = new List<DishPreference>();

    public void CreateRandomDishPreferences()
    {
        DishPreferences.Clear();

        for (int i = 0; i < 5; i++)
        {
            DishPreferences.Add(DishPreference.CreateRandom());
        }
    }
}

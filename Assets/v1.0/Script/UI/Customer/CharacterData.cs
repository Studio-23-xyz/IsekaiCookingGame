using System.Collections.Generic;
using UnityEngine;
 
using Random = System.Random;

[CreateAssetMenu(fileName = "CharacterData", menuName = "ScriptableObjects/CharacterData")]
public class CharacterData : ScriptableObject
{
    public string Name;
    public string Race;
    public string Occupation;
    [TextArea(30,500)]
    public string Backstory;
    public List<DishPreference> DishPreferences = new List<DishPreference>();
  
     

    private Random random;
     
[ContextMenu("Create Random Preference")]
    public void CreateRandomDishPreferences()
    {
        DishPreferences.Clear();

        for (int i = 0; i < 5; i++)
        {
            DishPreferences.Add(DishPreference.CreateRandom());
        }
    }

    public DishPreference SelectedDishPreferenceRandomly()
    {
        random = new Random();
        int randomIndex  = random.Next(DishPreferences.Count);
        DishPreference randomDishPreference = DishPreferences[randomIndex];
        return randomDishPreference;
    }
    
}

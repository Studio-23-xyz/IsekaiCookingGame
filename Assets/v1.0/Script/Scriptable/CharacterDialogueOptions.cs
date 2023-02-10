using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterDialogueOptions", menuName = "ScriptableObjects/CharacterDialogueOptions")]
public class CharacterDialogueOptions : ScriptableObject
{
    
    public List<string> initiatingConversationOptions;
    
    public List<string> orderingDishOptions;
    
    public List<string> likingFoodOptions;
     
    public List<string> dislikingFoodOptions;

    public string GetRandomInitiatingConversationOption()
    {
        return initiatingConversationOptions[Random.Range(0, initiatingConversationOptions.Count)];
    }

    public string GetRandomOrderingDishOption()
    {
        return orderingDishOptions[Random.Range(0, orderingDishOptions.Count)];
    }

    public string GetRandomLikingFoodOption()
    {
        return likingFoodOptions[Random.Range(0, likingFoodOptions.Count)];
    }

    public string GetRandomDislikingFoodOption()
    {
        return dislikingFoodOptions[Random.Range(0, dislikingFoodOptions.Count)];
    }
}
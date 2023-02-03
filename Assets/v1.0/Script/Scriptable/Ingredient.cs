using UnityEngine;

[CreateAssetMenu(fileName = "New Ingredient", menuName = "Ingredient")]
public class Ingredient : ScriptableObject
{
    public string name;
    public float weight;
    public float price;
    
    public FlavorValues flavorValues;

    public struct FlavorValues
    {
        [Range(0, 10)] public int umami;
        [Range(0, 10)] public int sour;
        [Range(0, 10)] public int sweet;
        [Range(0, 10)] public int spicy;
        [Range(0, 10)] public int bitter;
    }
}
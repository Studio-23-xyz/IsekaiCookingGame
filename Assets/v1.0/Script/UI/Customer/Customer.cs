using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Customer", menuName = "New Customer", order = 1)]
public class Customer : ScriptableObject
{
    public FoodData FoodData;
    public Characteristics Characteristics;

    public string MakeOrder()
    {
        //todo add personalization infront to show character
      return  $"{FoodData.RequestDish()}";
    }
}
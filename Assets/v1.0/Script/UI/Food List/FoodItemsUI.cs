using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class FoodItemsUI : MonoBehaviour
{

 //  public FoodItem[] FoodItems;

    [SerializeField] private Transform scrollViewContainer;

    [SerializeField] private GameObject foodItemCellUI;
    
    public  void Init( )
    {
       // if (FoodItems.Length == 0) FoodItems = GameManager.Instance.FoodItems;
        foreach (var item in GameManager.Instance.FoodItems)
        {
            Instantiate(foodItemCellUI, scrollViewContainer);
        }
    }

    
}

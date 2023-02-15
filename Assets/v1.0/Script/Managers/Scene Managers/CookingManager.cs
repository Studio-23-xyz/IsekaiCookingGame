using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingManager : MonoBehaviour
{
    public static CookingManager Instance;
    
    public InventoryUI InventoryUI;
    public DishUIBehaviour DishUIBehaviour;
  
    public IngredientItemDetailsUI IngredientItemDetailsUI;
    public DishInfoUI DishInfoUI;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DishUIBehaviour ??= GetComponentInChildren<DishUIBehaviour>();
        InventoryUI ??= GetComponentInChildren<InventoryUI>();
    }
    
}


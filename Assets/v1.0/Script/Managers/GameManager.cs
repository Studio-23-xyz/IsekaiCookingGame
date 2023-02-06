using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum GameState
{
    
}
public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance;
    [Header("Managers Reference")]
    
    public UIManager uIManager;
    
    
    public FoodItem[] FoodItems;
    public Customer[] Customers;

    
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

        if (uIManager == null) uIManager = GetComponentInChildren<UIManager>();
    }

    void Start()
    {
        FoodItems = Resources.LoadAll<FoodItem>("FoodItems");
        Customers = Resources.LoadAll<Customer>("Customers");
        
        
    }

    public void StartGame()
    {
       
    }
    public void ShowDialogue()
    {
        
    }
}

using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using System.IO;

public class InventoryManager : MonoBehaviour
{
    
  
   

    public Dictionary<FoodItem, int> Inventory = new Dictionary<FoodItem, int>();

    private string _filePath;


    public delegate void InventoryUpdate();

    public InventoryUpdate OnInventoryUpdate;

    private void Start()
    {
        
        Inventory.Clear();
        
        _filePath = Application.persistentDataPath + "/inventory.json";
        LoadInventory();
    }

    private void LoadInventory()
    {
        if (File.Exists(_filePath))
        {
            string json = File.ReadAllText(_filePath);
            Dictionary<string, int> savedInventory = JsonConvert.DeserializeObject<Dictionary<string, int>>(json);
            Inventory = new Dictionary<FoodItem, int>();
            foreach(KeyValuePair<string, int> itemName in savedInventory)
            {
                FoodItem item = Resources.Load<FoodItem>($"FoodItems/{itemName.Key}");
                if (item != null)
                {
                    AddFoodItem(item, itemName.Value);
                }
                else
                {
                    Debug.LogError("Unable to load food item: " + itemName);
                }
            }
        }
        else
        {
            Inventory = new Dictionary<FoodItem, int>();
        }
    }

    private void SaveInventory()
    {
        Dictionary<string, int> savedInventory = new Dictionary<string, int>();
        foreach (KeyValuePair<FoodItem, int> item in Inventory)
        {
            savedInventory.Add(item.Key.foodName, item.Value);
        }
        string json = JsonConvert.SerializeObject(savedInventory);
        File.WriteAllText(_filePath, json);
        
        OnInventoryUpdate?.Invoke();
    }

    public int AddFoodItem(FoodItem item, int quantity)
    {
        if (Inventory.ContainsKey(item))
        {
            Inventory[item] += quantity;
        }
        else
        {
            Inventory.Add(item, quantity);
        }
        SaveInventory();

        return 1;
    }

    public int RemoveFoodItem(FoodItem item, int quantity)
    {
        int returnValue = 0;
        
        if (Inventory.ContainsKey(item))
        {
            Inventory[item] -= quantity;
            if (Inventory[item] <= 0)
            {
                Inventory.Remove(item);

                returnValue = 1;
            }

           
        }
        SaveInventory();
        return returnValue;
        
        
    }
}
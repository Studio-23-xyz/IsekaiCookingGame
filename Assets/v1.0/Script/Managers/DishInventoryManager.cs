using UnityEngine;
using System.Collections.Generic;
using Newtonsoft.Json;

public class DishInventoryManager : MonoBehaviour
{
    public List<Dish> dishInventory;
    private string filePath;

    private void Awake()
    {
        filePath = Application.persistentDataPath + "/dishInventory.json";
    }

    private void Start()
    {
        LoadInventory();
    }

    public void AddDish(Dish dish)
    {
        dishInventory.Add(dish);
        SaveInventory();
    }

    public void RemoveDish(Dish dish)
    {
        dishInventory.Remove(dish);
        SaveInventory();
    }

    public void SaveInventory()
    {
        string json = JsonConvert.SerializeObject(dishInventory, Formatting.Indented);
        System.IO.File.WriteAllText(filePath, json);
    }

    public void LoadInventory()
    {
        if (System.IO.File.Exists(filePath))
        {
            string json = System.IO.File.ReadAllText(filePath);
            dishInventory = JsonConvert.DeserializeObject<List<Dish>>(json);
        }
        else
        {
            dishInventory = new List<Dish>();
        }
    }
}
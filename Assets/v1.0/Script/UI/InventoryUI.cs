using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryItemPrefab;
    public Transform contentParent;
    public InputField searchInput;
    public Dropdown categoryDropdown;
    public Dropdown flavorDropdown;

    private List<GameObject> inventoryItems = new List<GameObject>();
    private InventoryManager inventoryManager => GameManager.Instance.InventoryManager;


    private void Start()
    {
        
        categoryDropdown.options.Clear();
        categoryDropdown.options.Add(new Dropdown.OptionData("All"));
        
        categoryDropdown.options.AddRange(Enum.GetNames(typeof(FoodCategory)).ToList().Select(x => new Dropdown.OptionData(x.ToString())));
        categoryDropdown.value = 0;
        categoryDropdown.RefreshShownValue();

        flavorDropdown.options.Clear();
        flavorDropdown.options.Add(new Dropdown.OptionData("All"));
        flavorDropdown.options.AddRange(Enum.GetNames(typeof(Flavortype)).ToList().Select(x => new Dropdown.OptionData(x.ToString())));
        flavorDropdown.value = 0;
        flavorDropdown.RefreshShownValue();
        
         
        LoadInventoryItems();
        searchInput.onValueChanged.AddListener(delegate {
            FilterItems();
        });
        categoryDropdown.onValueChanged.AddListener(delegate {
            FilterItems();
        });
        flavorDropdown.onValueChanged.AddListener(delegate {
            FilterItems();
        });
    }

    private void LoadInventoryItems()
    {
        Dictionary<FoodItem, int> inventory = inventoryManager.Inventory;
        foreach (KeyValuePair<FoodItem, int> item in inventory)
        {
            GameObject inventoryItem = Instantiate(inventoryItemPrefab, contentParent);
            InventoryItemUI itemUI = inventoryItem.GetComponent<InventoryItemUI>();
            itemUI.Setup(new KeyValuePair<FoodItem, int>(item.Key, item.Value));
            inventoryItems.Add(inventoryItem);
        }
    }

    private void FilterItems()
    {
        foreach (GameObject item in inventoryItems)
        {
            InventoryItemUI itemUI = item.GetComponent<InventoryItemUI>();
            if (categoryDropdown.value > 0 && itemUI.Item.category != (FoodCategory)categoryDropdown.value - 1)
            {
                item.SetActive(false);
                continue;
            }
            if (flavorDropdown.value > 0 && itemUI.Item.flavorValue.Name != (Flavortype)flavorDropdown.value - 1)
            {
                item.SetActive(false);
                continue;
            }
            if (!itemUI.Item.name.ToLower().Contains(searchInput.text.ToLower()))
            {
                item.SetActive(false);
                continue;
            }
            item.SetActive(true);
        }
    }
    
    
   
    

}
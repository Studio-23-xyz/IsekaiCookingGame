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


    private void OnEnable()
    {
        GameManager.Instance.InventoryManager.OnInventoryUpdate += OnInventoryUpdate;
    }

    private void OnDisable()
    {
        GameManager.Instance.InventoryManager.OnInventoryUpdate -= OnInventoryUpdate;
    }

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

    
    private void OnInventoryUpdate()
    {
        LoadInventoryItems();
    }
    private void LoadInventoryItems()
    {
        contentParent.transform.DestroyAllChildren();
       //foreach (Transform item in contentParent)  Destroy(item.gameObject);
       
       
        inventoryItems = new List<GameObject>();
        
        var inventory = GameManager.Instance.InventoryManager.Inventory;
        foreach (KeyValuePair<FoodItem, int> item in inventory)
        {
            GameObject inventoryItem = Instantiate(inventoryItemPrefab, contentParent);
            InventoryItemUI itemUI = inventoryItem.GetComponent<InventoryItemUI>();
            itemUI.Setup(new KeyValuePair<FoodItem, int>(item.Key, item.Value));
            inventoryItems.Add(inventoryItem);
        }
    }
   /* private void ReloadInventoryItem(KeyValuePair<FoodItem, int> _inventory)
    {
        foreach (GameObject item in inventoryItems)
        {
            InventoryItemUI itemUI = item.GetComponent<InventoryItemUI>();
            if (itemUI.FoodItem == _inventory.Key)
            {
                itemUI.Setup(_inventory);
            }
        }
        
        
        
    }*/
    
    

    private void FilterItems()
    {
        foreach (GameObject item in inventoryItems)
        {
            InventoryItemUI itemUI = item.GetComponent<InventoryItemUI>();
            if (categoryDropdown.value > 0 && itemUI.FoodItem.category != (FoodCategory)categoryDropdown.value - 1)
            {
                item.SetActive(false);
                continue;
            }
            if (flavorDropdown.value > 0 && itemUI.FoodItem.flavorValue.Name != (Flavortype)flavorDropdown.value - 1)
            {
                item.SetActive(false);
                continue;
            }
            if (!itemUI.FoodItem.name.ToLower().Contains(searchInput.text.ToLower()))
            {
                item.SetActive(false);
                continue;
            }
            item.SetActive(true);
        }
    }
    
    
   
    

}
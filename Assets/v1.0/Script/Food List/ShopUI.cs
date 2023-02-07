using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private InputField searchInputField;
    [SerializeField] private Dropdown categoryDropdown;
    [SerializeField] private Dropdown flavorDropdown;
    [SerializeField] private Transform contentParent;
    [SerializeField] private ShopItemUI prefabShopItemUI;

    private List<FoodItem> foodItems;
    private List<ShopItemUI> foodDisplays = new List<ShopItemUI>();

    [SerializeField] private CartUIBehaviour _cartUIBehaviour;

    private void Start()
    {
        // Load food items from the resource folder
        foodItems = Resources.LoadAll<FoodItem>("FoodItems").ToList();

        // Setup dropdown options
        categoryDropdown.options.Clear();
        categoryDropdown.options.Add(new Dropdown.OptionData("All"));
        categoryDropdown.options.AddRange(foodItems.Select(x => x.category).Distinct().Select(x => new Dropdown.OptionData(x.ToString())));
        categoryDropdown.value = 0;
        categoryDropdown.RefreshShownValue();

        flavorDropdown.options.Clear();
        flavorDropdown.options.Add(new Dropdown.OptionData("All"));
        flavorDropdown.options.AddRange(foodItems.Select(x => x.flavorValue.Name).Distinct().Select(x => new Dropdown.OptionData(x.ToString())));
        flavorDropdown.value = 0;
        flavorDropdown.RefreshShownValue();

        // Create food displays
        UpdateFoodDisplays();

        // Add listener to search input field
        
        searchInputField.onValueChanged.AddListener(delegate {UpdateFoodDisplays(); });
        categoryDropdown.onValueChanged.AddListener(delegate {UpdateFoodDisplays(); });
        flavorDropdown.onValueChanged.AddListener(delegate {UpdateFoodDisplays(); });
         
        
    }

    

   

    private void UpdateFoodDisplays()
    {
        // Filter food items
        List<FoodItem> filteredFoodItems = foodItems.Where(x => 
            (categoryDropdown.value == 0 || x.category.ToString() == categoryDropdown.options[categoryDropdown.value].text) && 
            (flavorDropdown.value == 0 || x.flavorValue.Name.ToString() == flavorDropdown.options[flavorDropdown.value].text) && 
            (string.IsNullOrEmpty(searchInputField.text) || x.foodName.ToLower().Contains(searchInputField.text.ToLower()))
        ).ToList();

         
        // Clear existing food displays
        foreach (ShopItemUI foodDisplay in foodDisplays)
        {
            Destroy(foodDisplay.gameObject);
        }
        foodDisplays.Clear();

        // Create new food displays
        foreach (FoodItem foodItem in filteredFoodItems)
        {
            ShopItemUI shopItemUI = Instantiate(prefabShopItemUI, contentParent);
            shopItemUI.LoadFoodDisplay(foodItem);
            
            shopItemUI.OnFoodItemClick += OnFoodItemClick;
            
            foodDisplays.Add(shopItemUI);
        }
    }

    private void OnFoodItemClick(FoodItem fooditem)
    {
        _cartUIBehaviour.cart.AddItem(fooditem);
      
    }
}
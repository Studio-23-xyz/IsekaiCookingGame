using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class FoodListUI : MonoBehaviour
{
    [SerializeField] private InputField searchInputField;
    [SerializeField] private Dropdown categoryDropdown;
    [SerializeField] private Dropdown flavorDropdown;
    [SerializeField] private Transform contentParent;
    [SerializeField] private FoodDisplay prefabFoodDisplay;

    private List<FoodItem> foodItems;
    private List<FoodDisplay> foodDisplays = new List<FoodDisplay>();

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
        flavorDropdown.options.AddRange(foodItems.Select(x => x.flavorValue).Distinct().Select(x => new Dropdown.OptionData(x.ToString())));
        flavorDropdown.value = 0;
        flavorDropdown.RefreshShownValue();

        // Create food displays
        UpdateFoodDisplays();

        // Add listener to search input field
        searchInputField.onValueChanged.AddListener(UpdateFoodDisplays);

        // Add listeners to dropdown
        categoryDropdown.onValueChanged.AddListener(UpdateFoodDisplays);
        flavorDropdown.onValueChanged.AddListener(UpdateFoodDisplays);
    }

    private void UpdateFoodDisplays(string arg0)
    {
        throw new NotImplementedException();
    }

    private void UpdateFoodDisplays(int arg0)
    {
        throw new NotImplementedException();
    }

   

    private void UpdateFoodDisplays()
    {
        // Filter food items
        List<FoodItem> filteredFoodItems = foodItems.Where(x => 
            (categoryDropdown.value == 0 || x.category.ToString() == categoryDropdown.options[categoryDropdown.value].text) && 
            (flavorDropdown.value == 0 || x.flavorValue.ToString() == flavorDropdown.options[flavorDropdown.value].text) && 
            (string.IsNullOrEmpty(searchInputField.text) || x.name.Contains(searchInputField.text))
        ).ToList();

        // Clear existing food displays
        foreach (FoodDisplay foodDisplay in foodDisplays)
        {
            Destroy(foodDisplay.gameObject);
        }
        foodDisplays.Clear();

        // Create new food displays
        foreach (FoodItem foodItem in filteredFoodItems)
        {
            FoodDisplay foodDisplay = Instantiate(prefabFoodDisplay, contentParent);
            foodDisplay.LoadFoodDisplay(foodItem);
            foodDisplays.Add(foodDisplay);
        }
    }
}
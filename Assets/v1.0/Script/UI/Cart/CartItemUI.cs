using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CartItemUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI foodNameText;
    [SerializeField] private TextMeshProUGUI foodCountText;
    [SerializeField] private TextMeshProUGUI foodPriceText;

    
    [SerializeField] private Button increaseAmountBtn;
    [SerializeField] private Button decreaseAmountBtn;

    public delegate void AmountChangeEvent(FoodItem item);
    public AmountChangeEvent OnAmountIncrease;
    public AmountChangeEvent OnAmountDecrease;
    private FoodItem _foodItem;
    private void Start()
    {
        increaseAmountBtn.onClick.AddListener(()=> OnAmountIncrease?.Invoke(_foodItem));
        decreaseAmountBtn.onClick.AddListener(() => OnAmountDecrease?.Invoke(_foodItem));
    }

    public void Setup(KeyValuePair<FoodItem, int> item)
    {
        _foodItem = item.Key;
        foodNameText.text = item.Key.foodName;
        foodCountText.text = item.Value.ToString();
        foodPriceText.text = (item.Key.price * item.Value).ToString();
    }
    
}
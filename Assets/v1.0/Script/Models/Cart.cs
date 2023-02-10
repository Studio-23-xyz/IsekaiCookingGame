using System;
using System.Collections.Generic;
using UnityEngine;


 
public class Cart
{

    public delegate void CartChanged();

    public CartChanged OnCartChanged;
        
    public Dictionary<FoodItem, int> _cart
    {
        get;
    }
    public float Price { get { return CalculatePrice(); } }

    public Cart()
    {
        _cart = new Dictionary<FoodItem, int>();
    }

    public void AddItem(FoodItem item, int count = 1)
    {
        if (_cart.ContainsKey(item))
            _cart[item] += count;
        else
            _cart.Add(item, count);
        OnCartChanged?.Invoke();
    }

    public void RemoveItem(FoodItem item, int count = 1 )
    {
        if (_cart.ContainsKey(item) && _cart[item] > count)
            _cart[item] -= count;
        else
        {
            _cart.Remove(item);
        }
        OnCartChanged?.Invoke();
    }

    private float CalculatePrice()
    {
        float totalPrice = 0f;
        foreach (var item in _cart)
            totalPrice += item.Key.price * item.Value;
        return totalPrice;
    }

    public Dictionary<FoodItem, int> Purchase()
    {
        var items = new Dictionary<FoodItem, int>(_cart);
        _cart.Clear();
        return items;
    }
}
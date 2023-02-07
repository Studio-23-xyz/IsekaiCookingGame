using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class CartUIBehaviour : MonoBehaviour
{
    public Cart cart;

    private WalletManager _walletManager => GameManager.Instance.WalletManager;
     
    public Button purchaseButton;
    public GameObject itemPrefab;
    public Transform container;
    private InventoryManager _inventoryManager => GameManager.Instance.InventoryManager;
    private List<CartItemUI> _itemUIList = new List<CartItemUI>();

    private void Awake()
    {
        cart = new Cart();
         cart.OnCartChanged += UpdateUI;
        
    }

    


    private void Start()
    {
        UpdateUI();
        purchaseButton.interactable = _walletManager.Wallet.Gold >= cart.Price;
        
        purchaseButton.onClick.AddListener(OnPurchaseClicked);
    }

    public void UpdateUI( )
    {
        // Clear previous items
        foreach (CartItemUI itemUI in _itemUIList)
        {
            Destroy(itemUI.gameObject);
        }
        _itemUIList.Clear();

        // Add new items
        foreach (KeyValuePair<FoodItem, int> item in cart._cart)
        {
            GameObject itemGo = Instantiate(itemPrefab, container.transform);
            CartItemUI itemUI = itemGo.GetComponent<CartItemUI>();
            itemUI.Setup(new KeyValuePair<FoodItem, int>(item.Key, item.Value));
            _itemUIList.Add(itemUI);
        }
        purchaseButton.GetComponentInChildren<TextMeshProUGUI>().text = $"Purchase (<color=red>{cart.Price}</color>)";
        purchaseButton.interactable = _walletManager.Wallet.Gold >= cart.Price;
    }

    private void OnPurchaseClicked()
    {
        if (_walletManager.Wallet.Gold >= cart.Price)
        {
            _walletManager.RemoveGold(cart.Price);
        
            Dictionary<FoodItem, int> purchasedItems= cart.Purchase();
            
            foreach (var item in purchasedItems)
            {
                _inventoryManager.AddFoodItem(item.Key, item.Value);
            }
            UpdateUI();
        }
    }
}
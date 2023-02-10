using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CartUIBehaviour : MonoBehaviour
{
    public Cart cart;

    private WalletManager _walletManager => GameManager.Instance.WalletManager;

    public Button purchaseButton;
    public GameObject itemPrefab;
    public Transform container;
    private InventoryManager _inventoryManager => GameManager.Instance.InventoryManager;
    private List<CartItemUI> _itemUIList = new List<CartItemUI>();
    [SerializeField] private TextMeshProUGUI coinTxt;

    private void OnEnable()
    {
        cart = new Cart();
        cart.OnCartChanged += UpdateUI;

    }

    private void OnDisable()
    {
        cart.OnCartChanged -= UpdateUI;
    }


    private void Start()
    {
        UpdateUI();
        purchaseButton.interactable = _walletManager.Wallet.Gold >= cart.Price;
        coinTxt.text = $"{_walletManager.Wallet.Gold}";
        purchaseButton.onClick.AddListener(OnPurchaseClicked);
    }

    public void UpdateUI()
    {

        _itemUIList.Clear();

        container.transform.DestroyAllChildren();



        foreach (KeyValuePair<FoodItem, int> item in cart._cart)
        {
            GameObject itemGo = Instantiate(itemPrefab, container);
            CartItemUI CartItemUI = itemGo.GetComponent<CartItemUI>();
            CartItemUI.Setup(new KeyValuePair<FoodItem, int>(item.Key, item.Value));
            CartItemUI.OnAmountIncrease +=(item)=> cart.AddItem(item);
            CartItemUI.OnAmountDecrease +=(item)=> cart.RemoveItem(item);
            _itemUIList.Add(CartItemUI);
        }
        purchaseButton.GetComponentInChildren<TextMeshProUGUI>().text = $"Purchase (<color=red>{cart.Price}</color>)";
        purchaseButton.interactable = _walletManager.Wallet.Gold >= cart.Price;
    }

   

    private void OnPurchaseClicked()
    {
        if (_walletManager.Wallet.Gold >= cart.Price)
        {
            _walletManager.RemoveGold(cart.Price);

            Dictionary<FoodItem, int> purchasedItems = cart.Purchase();

            foreach (var item in purchasedItems)
            {
                _inventoryManager.AddFoodItem(item.Key, item.Value);
            }
            UpdateUI();
            purchaseButton.GetComponentInChildren<TextMeshProUGUI>().text = $"SUCCESSFUL!";
            coinTxt.text = $"{_walletManager.Wallet.Gold}";
        }
    }
}
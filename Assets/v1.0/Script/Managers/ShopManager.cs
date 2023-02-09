using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public ShopUI ShopUI;
    public CartUIBehaviour CartUIBehaviour;

    private void Awake()
    {
        if (ShopUI == null) ShopUI = transform.GetComponentInChildren<ShopUI>();
        if (CartUIBehaviour == null) CartUIBehaviour = transform.GetComponentInChildren<CartUIBehaviour>();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalInvoice : Invoice
{
    public float Amount;
    private void Start()
    {
        Amount = (float) GetInvoiceDiscount(100.0);
    }

    public override double GetInvoiceDiscount(double amount)
    {
        return base.GetInvoiceDiscount(amount) - 50;
    }
}

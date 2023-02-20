using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invoice : MonoBehaviour
{
    public virtual double GetInvoiceDiscount(double amount)
    {
        return amount - 10;
    }
}

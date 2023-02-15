using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvailableDishButtonController : MonoBehaviour
{

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

      private void Start()
        {
            _button.onClick.AddListener(ToggleDishUI);;
        }
      
      public GameObject DishInventoryUI;
    
      public void ToggleDishUI()
      {
          if (DishInventoryUI != null)
          {
              bool status = DishInventoryUI.gameObject.activeSelf;
              DishInventoryUI.gameObject.SetActive(!status);
          }
      }
      
    
}

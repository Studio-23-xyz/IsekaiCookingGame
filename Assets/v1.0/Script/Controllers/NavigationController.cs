using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavigationController : MonoBehaviour
{
    
    
   [SerializeField] private Button home;
   [SerializeField] private Button kitchen;
   [SerializeField] private Button restaurant;
   [SerializeField] private Button shop;
   [Header("Restaurant")]
   [SerializeField] private Button dishes;
   [Header("Home")]
   [SerializeField] private Button continueGame;
   [SerializeField] private Button newGame;
   [SerializeField] private Button loadGame;
   [SerializeField] private Button settings;
   [SerializeField] private Button quit;

   private void Awake()
   {
      home.onClick.AddListener(delegate { GameManager.Instance.sceneLoader.LoadScene("Home"); });
      kitchen.onClick.AddListener(delegate { GameManager.Instance.sceneLoader.LoadScene("Kitchen"); });
      restaurant.onClick.AddListener(delegate { GameManager.Instance.sceneLoader.LoadScene("Restaurant"); });
      shop.onClick.AddListener(delegate { GameManager.Instance.sceneLoader.LoadScene("Shop"); });
     
      
      continueGame.onClick.AddListener(delegate { GameManager.Instance.sceneLoader.LoadScene("Restaurant"); });
      newGame.onClick.AddListener(delegate { GameManager.Instance.StartGame(); });
      //loadGame.onClick.AddListener(delegate { GameManager.Instance.StartGame(); });
      
      settings.onClick.AddListener(delegate { GameManager.Instance.ToggleSettings(); });
      
      quit.onClick.AddListener(delegate { GameManager.Instance.QuitGame(); });
     
    
   }
   private void Start()
   {
       dishes.onClick.AddListener(delegate {GameManager.Instance.  DishInventoryManager.ToggleDishUI(); });;
   }
}

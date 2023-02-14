using System;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;



public enum GameState
{
    
}
public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance;
  
    
   
    
    
    public FoodItem[] FoodItems;
    public Customer[] Customers;

    [Header("CutScene")]
    public CutsceneData currentCutscene;
    public CutsceneData firstCutscene;
    public Action CutsceneEndAction;
    public SceneLoader sceneLoader;

    [Header("Managers Reference")]
    public WalletManager WalletManager;
    public InventoryManager InventoryManager;
      
     public DishInventoryManager DishInventoryManager;
     public CustomerManager CustomerManager;
     public SoundManager SoundManager;

    
     
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
             Destroy(gameObject);
        }

        WalletManager ??= GetComponentInChildren<WalletManager>();
        InventoryManager ??= GetComponentInChildren<InventoryManager>();
        
        
        DishInventoryManager ??= GetComponentInChildren<DishInventoryManager>();
        CustomerManager ??= GetComponentInChildren<CustomerManager>();
      
        SoundManager ??= GetComponentInChildren<SoundManager>();
    }

    void Start()
    {
        FoodItems = Resources.LoadAll<FoodItem>("FoodItems");
        Customers = Resources.LoadAll<Customer>("Customers");
        
       
       CutsceneEndAction=()=>
        {
            sceneLoader.LoadScene("Restaurant");
          // AudioManager.Instance.FadeOutChannel(AudioManager.AudioChannel.Bgm);
        };
    }
// UI StartButton OnClick
    public void StartGame()
    {
        sceneLoader.LoadCutScene();
    }
    public void ToggleSettings()
    {
        sceneLoader.LoadCutScene();
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void ProcessDish(Dish dish)
    {
        
            if (CustomerManager.CurrentCustomer.DishPreferences[0].CheckFlavorMatch(dish))
            {
                DialogueManager.Instance.SetState(DialogueState.LikingFood);
                WalletManager.AddGold(dish.PriceWithMarkUp());
                DialogueManager.Instance.ShowCoinText( dish.PriceWithMarkUp());
            }
            else
            {
                DialogueManager.Instance.ShowCoinText( 0);
                DialogueManager.Instance.SetState(DialogueState.DislikingFood);
            }
        
    }
}

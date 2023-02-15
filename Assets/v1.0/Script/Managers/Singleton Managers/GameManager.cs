using System;
using UnityEngine;



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
        
            if (CustomerManager.CurrentCustomerDishPreference.CheckFlavorMatch(dish))
            {
               CustomerManager.SetState(CustomerInteractionState.LikingFood);
                WalletManager.AddGold(dish.PriceWithMarkUp());
                
                DialogueManager.Instance. ShowDialogue(CustomerManager.currentCustomerInteractionState,
                    CustomerManager.CharacterDialogueOptions, CustomerManager.CurrentCustomerPhoto());
                
                DialogueManager.Instance.ShowCoinText( dish.PriceWithMarkUp());
            }
            else
            {
                DialogueManager.Instance.ShowCoinText( 0);
                CustomerManager.SetState(CustomerInteractionState.DislikingFood);
                
                DialogueManager.Instance. ShowDialogue(CustomerManager.currentCustomerInteractionState,
                    CustomerManager.CharacterDialogueOptions, CustomerManager.CurrentCustomerPhoto());
            }
           
        
    }
}

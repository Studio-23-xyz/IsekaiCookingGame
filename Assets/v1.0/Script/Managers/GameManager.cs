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
     public UIManager uIManager;
     public DishInventoryManager DishInventoryManager;
     
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
    }

    void Start()
    {
        FoodItems = Resources.LoadAll<FoodItem>("FoodItems");
        Customers = Resources.LoadAll<Customer>("Customers");
        
       
       CutsceneEndAction=()=>
        {
            sceneLoader.LoadScene("Start_Scene");
          // AudioManager.Instance.FadeOutChannel(AudioManager.AudioChannel.Bgm);
        };
    }
// UI StartButton OnClick
    public void StartGame()
    {
        sceneLoader.LoadCutScene();
    }
    
}

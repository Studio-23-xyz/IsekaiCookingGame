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
    [Header("Managers Reference")]
    
    public UIManager uIManager;
    
    
    public FoodItem[] FoodItems;
    public Customer[] Customers;

    [Header("CutScene")]
    public CutsceneData currentCutscene;
    public CutsceneData firstCutscene;
    public Action CutsceneEndAction;
    public SceneLoader sceneLoader;
    
    
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

        if (uIManager == null) uIManager = GetComponentInChildren<UIManager>();
    }

    void Start()
    {
        FoodItems = Resources.LoadAll<FoodItem>("FoodItems");
        Customers = Resources.LoadAll<Customer>("Customers");
        
        sceneLoader.LoadCutScene();
       CutsceneEndAction=()=>
        {
            sceneLoader.LoadScene("Start_Scene");
          // AudioManager.Instance.FadeOutChannel(AudioManager.AudioChannel.Bgm);
        };
        
        
        
    }

    public void StartGame()
    {
       
    }
    public void ShowDialogue()
    {
        
    }
}

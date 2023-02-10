using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DialogueState
{
    InitiatingConversation,
    OrderingDish,
    LikingFood,
    DislikingFood
}

public class DialogueManager : MonoBehaviour
{

    public static DialogueManager Instance;
    
    public DialogueUIBehaviour DialogueUIBehaviour;
    [SerializeField]  private List<Sprite> currentCustomerPhotos;
    
    public int currentCustomerPhoto;
    
    //public List<CharacterDialogueOptions> CharacterDialogueOptions;
    public CharacterDialogueOptions CharacterDialogueOptions;
  
    public DialogueState currentDialogueState;
    private int _maxIteration;
    private void Awake()
    {

        if (!PlayerPrefs.HasKey("currentCustomerPhoto"))   SetCurrentPlayerRandomPhoto();
        else currentCustomerPhoto =   PlayerPrefs.GetInt("currentCustomerPhoto", 0);
        
        
        
        currentDialogueState = (DialogueState) PlayerPrefs.GetInt("currentDialogueState", 0);
            
        
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        
        DialogueUIBehaviour ??= GetComponentInChildren<DialogueUIBehaviour>();
    }

   
    private void SetCurrentPlayerRandomPhoto()
    {
      int random = UnityEngine.Random.Range(0, currentCustomerPhotos.Count);

      if (random == currentCustomerPhoto)
      {
          SetCurrentPlayerRandomPhoto();
          _maxIteration++;
      }
      else
      {
          currentCustomerPhoto = random;
          _maxIteration = 0;
      }
      
      PlayerPrefs.SetInt("currentCustomerPhoto", currentCustomerPhoto);
    }
    private void Start()
    {
        DialogueUIBehaviour.gameObject.SetActive(true);
        DialogueUIBehaviour.ShowCharacter(currentCustomerPhotos[currentCustomerPhoto]);
        ShowDialogue();
    }
    
    public void SetState(DialogueState dialogueState)
    {
        currentDialogueState = dialogueState;
        PlayerPrefs.SetInt("currentDialogueState", (int)currentDialogueState);
        ShowDialogue();
    }

    public void MoveToNextState()
    {
        int nextState = (int)currentDialogueState + 1;
        if (nextState > (int)DialogueState.LikingFood)
        {
            nextState = (int)DialogueState.InitiatingConversation;
            SetCurrentPlayerRandomPhoto();

        }
        
        SetState((DialogueState) nextState);
       
    }
   
   
    private void ShowDialogue()
    {
        switch (currentDialogueState)
        {
            case DialogueState.InitiatingConversation:
                DialogueUIBehaviour.ShowCharacter(currentCustomerPhotos[currentCustomerPhoto]);
                DialogueUIBehaviour.ShowDialogue(CharacterDialogueOptions.GetRandomInitiatingConversationOption());
                break;

            case DialogueState.OrderingDish:
                DialogueUIBehaviour.ShowDialogue(CharacterDialogueOptions.GetRandomOrderingDishOption() + GameManager.Instance.CustomerManager.CurrentCustomer.DishPreferences[0].ToString(), "Serve a Dish",false);
                break;

            case DialogueState.LikingFood:
                DialogueUIBehaviour.ShowDialogue(CharacterDialogueOptions.GetRandomLikingFoodOption());
                break;

            case DialogueState.DislikingFood:
                DialogueUIBehaviour.ShowDialogue(CharacterDialogueOptions.GetRandomDislikingFoodOption());
                break;
        }
    }
    
   
    
}

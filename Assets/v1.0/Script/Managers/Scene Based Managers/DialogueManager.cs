using System;
using System.Collections.Generic;
using UnityEngine;





public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;
    
    [SerializeField] private DialogueUIBehaviour DialogueUIBehaviour;
    private CustomerManager _customerManager;

   private void Awake()
   {
       if (Instance == null) Instance = this;
       else Destroy(gameObject);
   }

   private void Start()
    {
        
        _customerManager = GameManager.Instance.CustomerManager;
        
        
        DialogueUIBehaviour.gameObject.SetActive(true);
        
        ShowDialogue(_customerManager.currentCustomerInteractionState,
            _customerManager.CharacterDialogueOptions, _customerManager.CurrentCustomerPhoto());
    }
   public void MoveToNextState()
    {
        _customerManager.MoveToNextState();
        ShowDialogue(_customerManager.currentCustomerInteractionState,
            _customerManager.CharacterDialogueOptions, _customerManager.CurrentCustomerPhoto());
    }
   
   public void ShowDialogue(CustomerInteractionState currentCustomerInteractionState, CharacterDialogueOptions CharacterDialogueOptions, Sprite currentCustomerPhoto)
    {
        switch (currentCustomerInteractionState)
        {
            case CustomerInteractionState.InitiatingConversation:
                DialogueUIBehaviour.ShowCharacter(currentCustomerPhoto);
                DialogueUIBehaviour.ShowDialogue(CharacterDialogueOptions.GetRandomInitiatingConversationOption());
                break;

            case CustomerInteractionState.OrderingDish:
                DialogueUIBehaviour.ShowCharacter(currentCustomerPhoto);
                DialogueUIBehaviour.ShowDialogue(CharacterDialogueOptions.GetRandomOrderingDishOption() + 
                                                 GameManager.Instance.CustomerManager.CurrentCustomerDishPreference.ToString(), "SERVE DISH",false);
                break;

            case CustomerInteractionState.LikingFood:
                DialogueUIBehaviour.ShowDialogue(CharacterDialogueOptions.GetRandomLikingFoodOption());
                break;

            case CustomerInteractionState.DislikingFood:
                DialogueUIBehaviour.ShowDialogue(CharacterDialogueOptions.GetRandomDislikingFoodOption());
                break;
        }
    }
    
    public void ShowCoinText(float amount)
    {
        DialogueUIBehaviour.ShowCoinText(amount);
    }
    
}

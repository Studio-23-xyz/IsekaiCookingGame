using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[Serializable]
public enum CustomerInteractionState
{
    InitiatingConversation,
    OrderingDish,
    LikingFood,
    DislikingFood
}
public class CustomerManager : MonoBehaviour
{
    
    public CharacterData CurrentCustomer;
    public DishPreference CurrentCustomerDishPreference;
  
  
    public CharacterDialogueOptions CharacterDialogueOptions;
    [SerializeField]  private List<Sprite> currentCustomerPhotos;
    public int currentCustomerPhoto;
    public CustomerInteractionState currentCustomerInteractionState;
  

    private void Start()
    {
        SelectACustomer();
    }

    public void SelectACustomer()
    {
        CurrentCustomerDishPreference = CurrentCustomer.SelectedDishPreferenceRandomly();
        currentCustomerPhoto = SetCurrentPlayerRandomPhoto();
        currentCustomerInteractionState = CustomerInteractionState.InitiatingConversation;
    }

    public Sprite CurrentCustomerPhoto()
    {
       return currentCustomerPhotos[currentCustomerPhoto];
    }
    private int SetCurrentPlayerRandomPhoto()
    {
        int random = UnityEngine.Random.Range(0, currentCustomerPhotos.Count);
        int   id = currentCustomerPhoto == random ?  random + 1 < currentCustomerPhotos.Count ? random+1 : 0 : random;
       Debug.Log($" SetCurrentPlayerRandomPhoto   ID : {id}");
       return id;
    }

    
    
    public void MoveToNextState()
    {
        int nextState = (int)currentCustomerInteractionState + 1;
        if (nextState > (int)CustomerInteractionState.LikingFood)
        {
            nextState = (int)CustomerInteractionState.InitiatingConversation;
            
            SelectACustomer();

        }
        
        currentCustomerInteractionState = (CustomerInteractionState) nextState;
       
    }
    
    public void SetState(CustomerInteractionState customerInteractionState)
    {
        int nextState = (int)currentCustomerInteractionState + 1;
        if (nextState > (int)CustomerInteractionState.LikingFood)
        {
            nextState = (int)CustomerInteractionState.InitiatingConversation;
           

        }
        
        currentCustomerInteractionState = customerInteractionState;
       
    }
    
    /*
    public List<CharacterData> AvailableCustomers = new List<CharacterData>();
    

   
    private void Start()
    {
        LoadCustomersFromResources();

        if (GetCurrentCustomer() != "")  CurrentCustomer = AvailableCustomers.FirstOrDefault(x => x.Name == GetCurrentCustomer());
      else   SelectCustomer(UnityEngine.Random.Range(0, AvailableCustomers.Count));
    }

    private void LoadCustomersFromResources()
    {
        AvailableCustomers.Clear();
        CharacterData[] customers = Resources.LoadAll<CharacterData>("Characters");
        AvailableCustomers.AddRange(customers);
    }

    public void SelectCustomer(int index)
    {
        if (index >= 0 && index < AvailableCustomers.Count)
        {
            CurrentCustomer = AvailableCustomers[index];
            SaveCustomerInfo();
        }
    }

    public void SaveCustomerInfo()
    {
        if (CurrentCustomer != null)
        {
            PlayerPrefs.SetString("CurrentCustomer", CurrentCustomer.Name);
        }
    }

    public string GetCurrentCustomer()
    {
         
          return  PlayerPrefs.GetString("CurrentCustomer", "");
        
    }*/
}
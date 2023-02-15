using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    
    
    public CharacterData CurrentCustomer;

  
    
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
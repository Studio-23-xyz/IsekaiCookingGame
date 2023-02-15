using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class WalletManager : MonoBehaviour
{


    public Wallet Wallet;

    private string walletFilePath =  "wallet.json";

    private void Start()
    {
        walletFilePath = Path.Combine(Application.persistentDataPath, walletFilePath);
        Load();
    }

    public void AddGold(float amount)
    {
        Wallet.Gold += amount;
    }

    public void RemoveGold(float amount)
    {
        Wallet.Gold -= amount;
    }

    public void AddSapphire(float amount)
    {
        Wallet.Sapphire += amount;
    }

    public void RemoveSapphire(float amount)
    {
        Wallet.Sapphire -= amount;
    }

    [ContextMenu("Save")]
    
    public void Save()
    {
        string json = JsonConvert.SerializeObject(Wallet);
        File.WriteAllText(walletFilePath, json);
    }

    public void Load()
    {
        if (File.Exists(walletFilePath))
        {
            string json = File.ReadAllText(walletFilePath);
            Wallet = JsonConvert.DeserializeObject<Wallet>(json);
        }
        else
        {
            Wallet = new Wallet();
            Wallet.Gold = 10000;
            Save();
        }
    }
}
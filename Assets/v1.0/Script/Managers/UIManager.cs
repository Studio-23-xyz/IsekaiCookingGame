using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    [SerializeField] private StartUIController startUIController;
    [SerializeField] private GameplayUIController gameplayUIController;


    public void StartGame()
    {
        startUIController.gameObject.SetActive(false);
        gameplayUIController.gameObject.SetActive(true);
    }
    
    
}

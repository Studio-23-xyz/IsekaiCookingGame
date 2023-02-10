using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerSingleton : MonoBehaviour
{
   public static bool Initialized;
   [SerializeField] private GameObject gameManger;
   private void Awake()
   {
      if(Initialized) Destroy(gameObject);
      Initialized = true;
      DontDestroyOnLoad(gameObject);
      gameManger.SetActive(true);
   }
}

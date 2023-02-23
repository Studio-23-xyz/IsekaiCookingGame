using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEventListener : MonoBehaviour
{
   [SerializeField] private CsharpToUXML _csharpToUxml;

   private void OnEnable()
   {
      _csharpToUxml.action1 += CsharpToUxmlOnAction1; // Subscription
      _csharpToUxml.action3 += CsharpToUxmlOnAction3; // Subscription
   }
   private void CsharpToUxmlOnAction1()
   {
      Debug.Log( $" OnClicked from ButtonEventListener");
   }
   private void CsharpToUxmlOnAction3(string value)
   {
      Debug.Log( $"ButtonEventListener OnClicked {value}");
   }

  
}

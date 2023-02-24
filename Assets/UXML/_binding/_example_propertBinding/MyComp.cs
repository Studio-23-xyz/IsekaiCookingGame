using System;
using System.ComponentModel;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
 

public class MyComp : MonoBehaviour
{
    [SerializeField] private UIDocument uiDocument;
   // [SerializeField] VisualTreeAsset _visualTreeAsset;
    [SerializeField] float m_Count;

    private void Awake()
    {
        uiDocument = GetComponent<UIDocument>();
        VisualElement root = uiDocument.rootVisualElement;
         
        
      //  root.Q<TextField>("m_Count").BindProperty(m_Count);
        // m_Count = SerializedObject.FindProperty("m_Count").floatValue;
    }
}
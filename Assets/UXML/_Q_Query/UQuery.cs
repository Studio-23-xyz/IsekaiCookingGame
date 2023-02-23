using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;



public class UQuery : MonoBehaviour
{
    // https://docs.unity3d.com/Manual/UIE-UQuery.html
    // [SerializeField] private VisualTreeAsset visualTreeAsset;
    private UIDocument uiDocument;
    private VisualElement root;
   
    void  OnClicked() {  Debug.Log( $" On Clicked");  }
    public event MyDelegate EventOnMyDelegate;
    public delegate void MyDelegate(string name);

    private Action action;
    private Action<int> action2;
    private void Awake()
    {
        uiDocument = GetComponent<UIDocument>();
        root = uiDocument.rootVisualElement;
       
        action = () => { Debug.Log( $" On Clicked");};
        // action2 = (x) => { Debug.Log( $" On Clicked");};
    }
    
    private void Start()
    {
        //  Get a button named OK, Q is the shorthand for Query<T>.First(). It returns the first element that matches the selection rules.
        /*  root.Q<Button>("OK")
         .RegisterCallback<MouseUpEvent> (x => action());*/
       
         /*
        //  Get all  buttons and assign registered a CallBack MouseUp Event
        root.Query<Button>().ForEach((button) =>
      {
          button.RegisterCallback<MouseUpEvent>(x => action());
      });*/
         
        
        /*
        //  Get all VisualElement named OK, then get button and assign registered a CallBack MouseUp Event
       List<VisualElement> result = root.Query("OK").ToList();
       result.ForEach(x=>x.Q<Button>().RegisterCallback<MouseUpEvent>(x => action()));
       */
        
        // Query by name, USS, Element Type, predicate
        List<VisualElement> result0 = root.Query("OK").ToList();
        VisualElement result1 = root.Query("OK").First();
        VisualElement result2 = root.Q("OK");     
        VisualElement result3 = root.Query("OK").AtIndex(1);
        VisualElement result4 = root.Query("OK").Last();
        List<VisualElement> result5 = root.Query(className: "yellow").ToList();
        List<VisualElement> result6 = root.Query(className: "yellow").Where(elem => elem.tooltip == "").ToList();
        VisualElement result7 = root.Query<Button>(className: "yellow", name: "OK").First();
       
        
        Button result8 = root.Query<VisualElement>("container2").Children<Button>("OK", className:"yellow").First();
        result8.text = "Selected!";
        result8.RegisterCallback<MouseUpEvent>(x =>action());
        
        root.Query().Where(elem => elem.tooltip == "").ForEach(elem => elem.tooltip="This is a tooltip!");
        
    }

   
}

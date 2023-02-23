using System;
using UnityEngine;
using UnityEngine.UIElements;

public class CsharpToUXML : MonoBehaviour
{
    private UIDocument uiDocument;
    private VisualElement root;
    
    delegate void AdditionDelegate(int a, int b);
    private AdditionDelegate addition;
    public Action<int, int> Sum;
    
    public Action action; //Action : public  delegate void Action;
    public Action action1;
    public Action<string> action2;
  
    public event Action3<string> action3;
    public delegate void Action3<T>(T value);

    private Action<string> action4;
    
   
    private void Awake()
    {
        uiDocument = GetComponent<UIDocument>();
        root = uiDocument.rootVisualElement;
       // WorkingWithButtonAndDelegate();
       WorkingWithToggle();
    }

    public void WorkingWithToggle()
    {
       
        var m_MyToggle = new Toggle("Test Toggle") { name = "My Toggle" };
        m_MyToggle.RegisterValueChangedCallback((evt) => { Debug.Log("Change Event received"); });
        root.Add(m_MyToggle);
    }

    private void WorkingWithButtonAndDelegate()
    {
        
        addition = delegate (int a, int b) {
            Debug.Log(a + b);
        };
        addition(3, 4); // will print: 7

        Sum = (int a, int b) =>
        {
            Debug.Log(a + b);
        };
        Sum(1, 5);
        
        action = () => { Debug.Log( $" On Clicked");};  // Subscription
        // action =  delegate{ Debug.Log( $" On Clicked");};  // Subscription
        action2 = (x) => { Debug.Log( $" On Clicked {x}");}; // Subscription
        // action3 = (x) => {Debug.Log( $" On Clicked {x}"); }; // Subscription
        action4 = delegate(string x) { Debug.Log( $" On Clicked {x}");};  // Subscription
        
        
        var buttonRed = new Button()
        {
            text = "ButtonRed"
        };
        buttonRed.clicked += action; // Event Invoke
        
        var buttonGreen = new Button(action1) //Button(action1.Invoke),  Event Invoke
        {
            text = "ButtonGreen"
        };
        
        var buttonYellow = new Button(){ text = "ButtonYellow"};
        buttonYellow.RegisterCallback<MouseUpEvent>(callback => action2($"buttonYellow {callback.clickCount}")); // Event Invoke
        
        Button buttonCyan = new Button(() => action3("ButtonCyan"))
        {
            text = "ButtonCyan"
        }; // Event Invoke

        Button buttonBlue = new Button(() => action4("ButtonBlue"))
        {
            text = "ButtonBlue"
        }; // Event Invoke

        root.Add(buttonCyan);
        root.Add(buttonGreen);
        root.Add(buttonRed);
        root.Add(buttonYellow);
        root.Add(buttonBlue);
    }
}

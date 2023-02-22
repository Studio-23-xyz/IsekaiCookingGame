using System;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
using Object = System.Object;

public class IntroductionToUXML : MonoBehaviour
{
   public UIDocument document;
   public VisualElement container;

    private void Awake()
    {
        document ??= GetComponent<UIDocument>();
        container = document.rootVisualElement;
    }

    private void Start()
    {
// BUTTON **********************************************************************************************
        // Action to perform when button is pressed.
        // Toggles the text on all buttons in 'container'.
        Action action = () =>
        {
            container.Query<Button>().ForEach((button) =>
            {
                button.text = button.text.EndsWith("Button") ? "Button (Clicked)" : "Button";
            });
        };

      // Get a reference to the Button from UXML and assign it its action.
        var uxmlButton = container.Q<Button>("the-uxml-button");
         uxmlButton.RegisterCallback<MouseUpEvent>((evt) => action());

       // Create a new Button with an action and give it a style class.
        var csharpButton = new Button(action) { text = "C# Button" };
        csharpButton.AddToClassList("some-styled-button");
        container.Add(csharpButton);
        
// SCROLLER **********************************************************************************************
        
        // Get a reference to the scroller from UXML and assign it its value.
        var uxmlField = container.Q<Scroller>("the-uxml-scroller");
        uxmlField.valueChanged += (v) => {};
        uxmlField.value = 42;

        // Create a new scroller, disable it, and give it a style class.
        var csharpField = new Scroller(0, 100, (v) => {}, SliderDirection.Vertical);
        csharpField.SetEnabled(false);
        csharpField.AddToClassList("some-styled-scroller");
        csharpField.value = uxmlField.value;
        container.Add(csharpField);

        // Mirror value of uxml scroller into the C# field.
        uxmlField.RegisterCallback<ChangeEvent<float>>((evt) =>
        {
            csharpField.value = evt.newValue;
        });
        
// TOGGLE **********************************************************************************************

// Get a reference to the field from UXML and assign it its value.
        var field = container.Q<Toggle>("the-uxml-field");
        field.value = true;

// Create a new field, disable it, and give it a style class.
        var toggle = new Toggle("C# Field");
        toggle.value = false;
        toggle.SetEnabled(false);
        toggle.AddToClassList("some-styled-field");
        toggle.value = field.value;
        container.Add(toggle);

// Mirror value of uxml field into the C# field.
        field.RegisterCallback<ChangeEvent<bool>>((evt) =>
        {
            toggle.value = evt.newValue;
        });
        
        
// LABEL **********************************************************************************************   
// Get a reference to the label from UXML and update its text.
        var uxmlLabel = container.Q<Label>("the-uxml-label");
        uxmlLabel.text += " (Updated in C#)";

// Create a new label and give it a style class.
        var csharpLabel = new Label("C# Label");
        csharpLabel.AddToClassList("some-styled-label");
        container.Add(csharpLabel);
        
// Text Field **********************************************************************************************    
        
        // Get a reference to the field from UXML and append to it its value.
        var inputField = container.Q<TextField>("the-uxml-field");
        inputField.value += "..";

// Create a new field, disable it, and give it a style class.
        var textField = new TextField("C# Field");
        textField.value = "It's snowing outside...";
        textField.SetEnabled(false);
        textField.AddToClassList("some-styled-field");
        textField.value = inputField.value;
        container.Add(textField);

// Mirror value of uxml field into the C# field.
        inputField.RegisterCallback<ChangeEvent<string>>((evt) =>
        {
            textField.value = evt.newValue;
        });       

// HELP BOX **************************************************************************************************
// Get a reference to the help box from UXML and update its text.
        var uxmlHelpBox = container.Q<HelpBox>("the-uxml-help-box");
        uxmlHelpBox.text += " (Updated in C#)";

// Create a new help box and give it a style class.
        var csharpHelpBox = new HelpBox("This is a help box", HelpBoxMessageType.Warning);
        csharpHelpBox.AddToClassList("some-styled-help-box");
        container.Add(csharpHelpBox);

// UXML Field **********************************************************************************************
// Get a reference to the field from UXML and assign it its value.
            var objectField = container.Q<ObjectField>("the-uxml-field");
            objectField.value = new Texture2D(10, 10) { name = "new_texture" };

// Create a new field, disable it, and give it a style class.
            var child = new ObjectField("C# Field");
            child.SetEnabled(false);
            child.AddToClassList("some-styled-field");
            child.value = objectField.value;
            container.Add(child);

// Mirror value of uxml field into the C# field.
            objectField.RegisterCallback<ChangeEvent<Object>>((evt) =>
            {
                    child.value = (UnityEngine.Object) evt.newValue;
            });
            
// LIST VIEW *************************************************************************************************

// Create some list of data, here simply numbers in interval [1, 1000]
            const int itemCount = 1000;
            var items = new List<string>(itemCount);
            for (int i = 1; i <= itemCount; i++)
                    items.Add(i.ToString());

// The "makeItem" function will be called as needed
// when the ListView needs more items to render
            Func<VisualElement> makeItem = () => new Label();

// As the user scrolls through the list, the ListView object
// will recycle elements created by the "makeItem"
// and invoke the "bindItem" callback to associate
// the element with the matching data item (specified as an index in the list)
            Action<VisualElement, int> bindItem = (e, i) => (e as Label).text = items[i];

            var listView = container.Q<ListView>();
            listView.makeItem = makeItem;
            listView.bindItem = bindItem;
            listView.itemsSource = items;
            listView.selectionType = SelectionType.Multiple;

// Callback invoked when the user double clicks an item
            listView.onItemsChosen += Debug.Log;

// Callback invoked when the user changes the selection inside the ListView
            listView.onSelectionChange += Debug.Log;
            
    }
}

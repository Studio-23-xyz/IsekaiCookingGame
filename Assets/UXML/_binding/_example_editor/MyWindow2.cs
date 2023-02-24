using System;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;


[System.Serializable]
public class MyModel
{
    public MyModel(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    public string name;
  public int age;
}
public class MyWindow2 : EditorWindow
{
     
    [SerializeField]
    VisualTreeAsset visualTree;
    [MenuItem("Window/UXML Binding")]
    public static void ShowWindow()
    {
        EditorWindow w = GetWindow(typeof(MyWindow2));
        /*
        VisualTreeAsset uiAsset  = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/UXML/_binding/index.uxml");
        VisualElement ui = uiAsset.Instantiate();
        w.rootVisualElement.Add(ui);
        */
    }

    public void CreateGUI()
    {
        visualTree.CloneTree(rootVisualElement); // VisualTree will be clone to rootVisualElement
        OnSelectionChange();
    }
    private void OnSelectionChange()
    {
        GameObject selectedObject = Selection.activeObject as GameObject;
        if (selectedObject != null)
        {
            // Create the SerializedObject from the current selection
           
             
            SerializedObject so = new SerializedObject(selectedObject);
            // Bind it to the root of the hierarchy. It will find the right object to bind to.
            rootVisualElement.Bind(so);
        }
        else
        {
            // Unbind the object from the actual visual element
            rootVisualElement.Unbind();

            // Clear the TextField after the binding is removed
            var textField = rootVisualElement.Q<TextField>("GameObjectName");
            if (textField != null)
            {
                textField.value = string.Empty;
            }
        }
    }
}
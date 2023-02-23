using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class MyWindow : EditorWindow
{
    [MenuItem("Window/UXML Window")]
    public static void ShowWindow()
    {
        EditorWindow w = GetWindow(typeof(MyWindow));
       
        VisualTreeAsset uiAsset = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/UXML/_editorWindow/index.uxml");
        VisualElement ui = uiAsset.Instantiate();

        w.rootVisualElement.Add(ui);

    }

/*
 VisualTreeAsset uxml = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/main_window.uxml");
StyleSheet uss = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Editor/main_styles.uss");
 */
    
    /*VisualTreeAsset uxml = Resources.Load<VisualTreeAsset>("main_window");
    StyleSheet uss = Resources.Load<StyleSheet>("main_styles");*/
}
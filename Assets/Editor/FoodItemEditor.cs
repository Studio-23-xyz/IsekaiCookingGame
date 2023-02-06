using UnityEditor;
using UnityEngine;
using System.IO;

public class FoodItemEditor : EditorWindow
{
    private string csvInput;

    [MenuItem("Window/Generate Food Items")]
    public static void ShowWindow()
    {
        GetWindow<FoodItemEditor>("Generate Food Items");
    }

    private void OnGUI()
    {
        csvInput = EditorGUILayout.TextArea(csvInput, GUILayout.Height(position.height - 50));

        if (GUILayout.Button("Generate"))
        {
            GenerateFoodItems();
        }
    }

    private void GenerateFoodItems()
    {
        string path = "Assets/Resources";
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        path += "/FoodItems";
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        FoodItem[] foodItems = FoodItem.FromCSV(csvInput);
        foreach (FoodItem foodItem in foodItems)
        {
            string assetPath = path + "/" + foodItem.name + ".asset";
            FoodItem existingFoodItem = AssetDatabase.LoadAssetAtPath<FoodItem>(assetPath);
            if (existingFoodItem == null)
            {
                AssetDatabase.CreateAsset(foodItem, assetPath);
            }
            else
            {
                EditorUtility.DisplayDialog("Asset Already Exists", "An asset with the name '" + foodItem.name + "' already exists at the path '" + assetPath + "'. Skipping.", "OK");
            }
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }

}

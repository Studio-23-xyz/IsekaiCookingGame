using System.IO;
using UnityEditor;
using UnityEngine;
using Newtonsoft.Json;

public class CharacterDataImporterEditor : EditorWindow
{
    private string _filePath;
    [MenuItem("Window/Import Character Data")]
    private static void ShowWindow()
    {
        GetWindow<CharacterDataImporterEditor>("Import Character Data");
    }

    private void OnGUI()
    {
        GUILayout.Label("File Path", EditorStyles.boldLabel);
        _filePath = EditorGUILayout.TextField("", _filePath);

        if (GUILayout.Button("Import"))
        {
            ImportCharacterData();
        }
    }

    private void ImportCharacterData()
    {
        if (string.IsNullOrEmpty(_filePath))
        {
            Debug.LogError("File path is empty");
            return;
        }

        if (!File.Exists(_filePath))
        {
            Debug.LogError("File does not exist");
            return;
        }

        string fileContent = File.ReadAllText(_filePath);
        CharacterData[] characterDataArray = JsonConvert.DeserializeObject<CharacterData[]>(fileContent);

        string resourcePath = "Assets/Resources/Characters/";
        if (!Directory.Exists(resourcePath))
        {
            Directory.CreateDirectory(resourcePath);
        }

        foreach (CharacterData characterData in characterDataArray)
        {
            string assetPath = resourcePath + characterData.Name + ".asset";

            if (AssetDatabase.LoadAssetAtPath<CharacterData>(assetPath) != null)
            {
                Debug.LogWarning("Character Data asset already exists, skipping: " + characterData.Name);
                continue;
            }

            AssetDatabase.CreateAsset(characterData, assetPath);
            characterData.CreateRandomDishPreferences();
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}
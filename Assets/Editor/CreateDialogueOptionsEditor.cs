using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEditor;
using UnityEngine;

public class CreateDialogueOptionsEditor : EditorWindow
{
    private string jsonArray;

    [MenuItem("Window/Create Dialogue Options")]
    public static void ShowWindow()
    {
        GetWindow<CreateDialogueOptionsEditor>("Create Dialogue Options");
    }

    private void OnGUI()
    {
        jsonArray = EditorGUILayout.TextArea(jsonArray, GUILayout.Height(position.height - 80));

        if (GUILayout.Button("Create Dialogue Options"))
        {
            CreateDialogueOptions();
        }
    }

    private void CreateDialogueOptions()
    {
        string[] dialogueOptionArrays = JsonConvert.DeserializeObject<string[]>(jsonArray);

        string dialogueOptionsFolderPath = "Assets/Resources/DialogueOptions";
        if (!Directory.Exists(dialogueOptionsFolderPath))
        {
            Directory.CreateDirectory(dialogueOptionsFolderPath);
        }

        foreach (string dialogueOptionArray in dialogueOptionArrays)
        {
            CharacterDialogueOptions dialogueOptions = CreateInstance<CharacterDialogueOptions>();
            dialogueOptions.initiatingConversationOptions = JsonConvert.DeserializeObject<List<string>>(dialogueOptionArray);
            dialogueOptions.orderingDishOptions = JsonConvert.DeserializeObject<List<string>>(dialogueOptionArray);
            dialogueOptions.likingFoodOptions = JsonConvert.DeserializeObject<List<string>>(dialogueOptionArray);
            dialogueOptions.dislikingFoodOptions = JsonConvert.DeserializeObject<List<string>>(dialogueOptionArray);

            AssetDatabase.CreateAsset(dialogueOptions, $"{dialogueOptionsFolderPath}/{dialogueOptionArray}.asset");
            AssetDatabase.SaveAssets();
        }

        AssetDatabase.Refresh();
    }
}
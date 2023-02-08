using UnityEngine;
using UnityEditor;
using Newtonsoft.Json.Linq;

public class CharacterDataImporterEditor : EditorWindow
{
    [MenuItem("Tools/Import Character Data")]
    public static void ImportData()
    {
        string csvString = " ";
        ImportDataFromString(csvString);
    }

    private static void ImportDataFromString(string csvString)
    {
        string[] lines = csvString.Split('\n');
        string[] header = lines[0].Split(',');
        for (int i = 1; i < lines.Length; i++)
        {
            string[] fields = lines[i].Split(',');
            JObject obj = new JObject();
            for (int j = 0; j < header.Length; j++)
            {
                obj[header[j]] = fields[j];
            }

            string name = obj["Name"].ToString();
            string race = obj["Race"].ToString();
            string occupation = obj["Occupation"].ToString();
            string backstory = obj["Backstory"].ToString();

            CharacterData characterData = ScriptableObject.CreateInstance<CharacterData>();
            characterData.Name = name;
            characterData.Race = race;
            characterData.Occupation = occupation;
            characterData.Backstory = backstory;

            string path = "Assets/Resources/CharacterData/" + name + ".asset";
            AssetDatabase.CreateAsset(characterData, path);
        }
    }
}
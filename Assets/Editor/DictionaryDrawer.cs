using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

[CustomPropertyDrawer(typeof(Dictionary<,>))]
public class DictionaryDrawer : PropertyDrawer
{
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUI.GetPropertyHeight(property, label, true);
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        SerializedProperty keys = property.FindPropertyRelative("keys");
        SerializedProperty values = property.FindPropertyRelative("values");

        float lineHeight = EditorGUIUtility.singleLineHeight;
        float lineSpacing = EditorGUIUtility.standardVerticalSpacing;
        float labelWidth = EditorGUIUtility.labelWidth;
        float valueWidth = position.width - labelWidth;

        Rect keyLabelRect = new Rect(position.x, position.y, labelWidth, lineHeight);
        EditorGUI.LabelField(keyLabelRect, "Key");

        Rect valueLabelRect = new Rect(position.x + labelWidth, position.y, valueWidth, lineHeight);
        EditorGUI.LabelField(valueLabelRect, "Value");

        for (int i = 0; i < keys.arraySize; i++)
        {
            SerializedProperty key = keys.GetArrayElementAtIndex(i);
            SerializedProperty value = values.GetArrayElementAtIndex(i);

            Rect keyRect = new Rect(position.x, position.y + (lineHeight + lineSpacing) * (i + 1), labelWidth, lineHeight);
            EditorGUI.PropertyField(keyRect, key, GUIContent.none);

            Rect valueRect = new Rect(position.x + labelWidth, position.y + (lineHeight + lineSpacing) * (i + 1), valueWidth, lineHeight);
            EditorGUI.PropertyField(valueRect, value, GUIContent.none);
        }

        EditorGUI.EndProperty();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
[CustomEditor(typeof(RUIFix))]
public class RUIFixEditor : Editor
{
    RUIFix ruiFix;
    ReorderableList panelIDs;
    string[] ids;
    public void OnEnable()
    {
        ruiFix = target as RUIFix;
        panelIDs = new ReorderableList(serializedObject, serializedObject.FindProperty("panelIDs"));
        panelIDs.drawHeaderCallback = rect =>
        {
            EditorGUI.LabelField(rect, "Active Panel Id", " : RaksUI System");
        };
        panelIDs.drawElementCallback = (Rect rect,int index,bool isActive,bool focus)=>
        {
            var element = panelIDs.serializedProperty.GetArrayElementAtIndex(index);
            EditorGUI.PropertyField(new Rect(rect), element);
        };
    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.Space();
        panelIDs.DoLayoutList();
        serializedObject.ApplyModifiedProperties();
    }
}

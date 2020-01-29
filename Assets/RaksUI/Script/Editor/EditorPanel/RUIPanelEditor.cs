using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(RUIPanel))]
public class RUIPanelEditor : Editor
{
    string[] panelIDs;
    int panelIdIndex = 0;
    RUIPanel rUIPanel;
    private void OnEnable()
    {
        rUIPanel = target as RUIPanel;
        Debug.Log(panelIdIndex+" : "+rUIPanel.startPanel);
        var panels = rUIPanel.GetComponentsInChildren<RUIPanelChild>();
        panelIDs = new string[panels.Length];
        for (int i = 0; i < panels.Length; i++)
        {
            panelIDs[i] = panels[i].Id;
            if (panels[i].Id.Equals(rUIPanel.startPanel))
            {
                panelIdIndex = i;
            }
        }
    }
    public override void OnInspectorGUI()
    {
        EditorGUILayout.HelpBox("Raks UI Panel Inspector Hoş Geldiniz !", MessageType.None,true);
        EditorGUILayout.Space();
        panelIdIndex = EditorGUILayout.Popup("Start Panel ID :",panelIdIndex, panelIDs);
        if (panelIDs.Length > 0)
        {
            rUIPanel.startPanel = panelIDs[panelIdIndex];
        }

        EditorUtility.SetDirty(target);
    }
}

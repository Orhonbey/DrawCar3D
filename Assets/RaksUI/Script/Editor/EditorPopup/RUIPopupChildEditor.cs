using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
/// <summary>
/// 
/// </summary>
/// 
[CustomEditor(typeof(RUIPopupChild))]
public class RUIPopupChildEditor : Editor
{
    RUIPopupChild value;
    private void OnEnable()
    {
        value = target as RUIPopupChild;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        value.Id = value.Id.ToLower();
    }
}

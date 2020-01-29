using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 
/// Raks Game UI Sistemi
/// Sunal Orhon Tarafından Yapılmıştır .
/// 
/// </summary>
public class RUICreate : Editor
{
    [MenuItem("RaksUI/Create/Canvas", false,1)]
    [MenuItem("GameObject/RaksUI/Create/Canvas",false,0)]
    public static void CreateCanvas()
    {
        //----> Canvas Olşturuldu 
        GameObject rCanvas = new GameObject();
        rCanvas.AddComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
        rCanvas.AddComponent<RCanvas>();
        rCanvas.AddComponent<CanvasScaler>();
        rCanvas.AddComponent<GraphicRaycaster>();
        rCanvas.name = "Rask Canvas";
        var rCScaler = rCanvas.GetComponent<CanvasScaler>();
        rCScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        rCScaler.referenceResolution = new Vector2(1920, 1080);
        //----> RUI Panel Create
        GameObject ruiPanel = new GameObject();
        ruiPanel.AddComponent<RUIPanel>();
        ruiPanel.name = "RUIPanel";
        ruiPanel.transform.SetParent(rCanvas.transform);
        //---->Fix Panel
        GameObject ruiFix = new GameObject();
        ruiFix.name = "RUIFixPanel";
        ruiFix.AddComponent<RUIFixPanel>();
        ruiFix.transform.SetParent(rCanvas.transform);
        //----> Popup
        GameObject ruiPopup = new GameObject();
        ruiPopup.AddComponent<RUIPopup>();
        ruiPopup.name = "RUIPopup";
        ruiPopup.transform.SetParent(rCanvas.transform);
        //----> Waiting
        GameObject waiting = new GameObject();
        waiting.AddComponent<RUIWaiting>();
        waiting.name = "RUIWaiting";
        waiting.transform.SetParent(rCanvas.transform);
    }
    [MenuItem("RaksUI/Create/RUIPanel", false, 1)]
    [MenuItem("GameObject/RaksUI/Create/RUIPanel", false, 0)]
    public static void CreatePanel()
    {
        Debug.Log("Çalışmalar Devam ediyor.");
        GameObject ruiPanel = new GameObject("RUIPanel-Panel");
        var c = FindObjectOfType<RUIPanel>();
        ruiPanel.transform.SetParent(c.transform);
        ruiPanel.AddComponent<RUIPanelChild>();
    }

}

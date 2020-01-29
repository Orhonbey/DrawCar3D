using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// RUIPanel En üstteki Panelde Duracak ve Buradan Alttaki Bütün Paneller Yönetilcek .
/// Bunu 
/// </summary>
public class RUIPanel : MonoBehaviour
{
    #region //----> Variable
    /// <summary>
    /// Oluşturulan ve Yönetilecek olan Panelleri Tutacak Olan Dictinary
    /// </summary>
    public static Dictionary<string, RUIPanelChild> panelList = new Dictionary<string, RUIPanelChild>();
    /// <summary>
    /// aktif Panel Barındırıyoruz 
    /// </summary>
    public static RUIPanelChild activePanel;
    [Header("Raks Game UI")]
    public string startPanel;
    #endregion
    #region //----> Method
    private void Start()
    {
        //----> Burada Altındakilere Ulaşılacak .
        GetChild();
    }
    private void GetChild()
    {
        var childs = GetComponentsInChildren<RUIPanelChild>();
        foreach (var item in childs)
        {
            panelList.Add(item.Id, item);
            if (!startPanel.Equals(item.Id))
                item.ShotDown();
            else 
                activePanel = item;
        }
    }
    /// <summary>
    /// Open İşlemi Açılacak Olan Panel Id verilir ve o Panel Açılır .
    /// </summary>
    /// <param name="panelID"></param>
    /// <returns></returns>
    public static RUIPanelChild Open(string panelID)
    {
        if (activePanel != null && !activePanel.Id.Equals(panelID))
        {
            activePanel.Close();
        }
        if (panelList.TryGetValue(panelID,out var panel))
        {
            panel.Open();

            return panel;
        }
        return null;
    }
    public static RUIPanelChild Close(string panelID)
    {
        if (activePanel.Id.Equals(panelID))
        {
            activePanel.Close();
            return activePanel;
        }
        return null;
    }
    #endregion
}

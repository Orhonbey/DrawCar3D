using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Bu Yapı Bir Panel Yapısı Sayıla bilir.
/// Hangi panelde Bu Obje Aktif olacak Onu Belirten bir yapıdır .
/// Buna Fix Diyoruz .
/// </summary>
public class RUIFix : MonoBehaviour
{
    #region //----> Variable
    public List<string> panelIDs = new List<string>();
    public CanvasGroup myCanvasGroup;
    #endregion
    #region //----> My Method
    private void Awake()
    {
        myCanvasGroup = GetComponent<CanvasGroup>();
    }
    /// <summary>
    /// Fix UI Verilen Id ile Açıkmı kalacak yoksa kapalımı kalacak onu buluyoruz .
    /// </summary>
    /// <param name="panelID"></param>
    /// <returns></returns>
    public bool ShotDown(string panelID)
    {
        if (panelIDs.Contains(panelID))
        {
            myCanvasGroup.LeanAlpha(1,0);
            myCanvasGroup.interactable = true;
            return true;
        }
        else
        {
            myCanvasGroup.interactable = false;
            myCanvasGroup.LeanAlpha(0, 0);
        }
        return false;
    }
    #endregion

}

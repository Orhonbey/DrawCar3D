using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RUIPopupChild : RUIMaster
{
    #region //----> Variable
    private static RUIPopupChild m;
    public RUISetText popupTitle;
    public RUISetText popupText;
    /// <summary>
    /// Popup Açılmaya alteernatif Olarak kullanılır 
    /// </summary>
    public RUIPopupChild OnOpen
    {
        get
        {
            Open();
            return this;
        }
    }
    #endregion
    #region //----> Method
    private void Awake()
    {
        m = this;
        myCanvasGroup = GetComponent<CanvasGroup>();
        myRectTransform = GetComponent<RectTransform>();
        GetText();
    }
    private void GetText()
    {
        var tt = GetComponentsInChildren<RUISetText>();
        foreach (var item in tt)
        {
            switch (item.textType)
            {
                case RUITextType.title:
                    popupTitle = item;
                    break;
                case RUITextType.text:
                    popupText = item;
                    break;
            }
        }
    }
    /// <summary>
    /// Başlığı Değiştirmeye yarar
    /// </summary>
    /// <param name="title"></param>
    /// <returns></returns>
    public RUIPopupChild SetTitle(string title)
    {
        popupTitle.SetText = title;
        return m;
    }
    /// <summary>
    /// Açılır Menudeki Metini Değiştirmeye yarar.
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public RUIPopupChild SetText(string text)
    {
        popupText.SetText = text;
        return m;
    }
    #endregion
}

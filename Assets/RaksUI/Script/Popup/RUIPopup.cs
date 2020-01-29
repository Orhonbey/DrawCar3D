using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RUIPopup : MonoBehaviour
{
    #region //----> Variable
    static RUIPopup m;
    public static Dictionary<string, RUIPopupChild> popupList = new Dictionary<string, RUIPopupChild>();
    public static RUIPopupChild activePopup;
    #endregion
    #region //----> Method
    private void Awake()
    {
        m = this;
    }
    private void Start()
    {
        GetChild();
    }
    private void GetChild()
    {
        var childs = GetComponentsInChildren<RUIPopupChild>();
        foreach (var item in childs)
        {
            item.ShotDown();
            popupList.Add(item.Id, item);
        }
    }
    public static RUIPopupChild Get(string panelId)
    {
        if (popupList.TryGetValue(panelId,out var value))
        {
            return value;
        }
        return null;
    }
    #endregion
}

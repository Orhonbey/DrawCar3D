using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Editor Yazılacak .
/// </summary>
public class RUIPanelChild : RUIMaster
{
    #region //----> Variable
    [Tooltip("Geriye gidelecek olan yapının Id si")]
    public string backId;   
    #endregion
    public override void AnimationBegin()
    {
        base.AnimationBegin();
        RUIPanel.activePanel = this;
        RUIFixPanel.FixOpen(Id);
    }
}

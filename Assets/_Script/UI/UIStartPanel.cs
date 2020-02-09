using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStartPanel : MonoBehaviour
{
    #region //----> My Method
    public void PlayButton()
    {
        GameManager.ins.gMode = GameMode.play;
        RUIPanel.Open("game");
    }
    #endregion
}

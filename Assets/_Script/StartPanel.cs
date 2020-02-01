using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : MonoBehaviour
{
    #region //----> My Method
    public void PanelUpdate()
    {
        var level = GameManager.ins.currentLevel;
        GameManager.ins.levelcount.text = level.levelName;

        for (int i = 0; i < GameManager.ins.levelImage.Length; i++)
        {
            if ((i+1) <= level.levelNumber)
            {
                GameManager.ins.levelImage[i].sprite = GameManager.ins.activelevel;
            }
            else
            {
                GameManager.ins.levelImage[i].sprite = GameManager.ins.defaultLevel;
            }
        }
    }

    public void GamePlay()
    {
        GameManager.ins.currentGameMode = GameMode.play;
        RUIPanel.Open("play");
    }
    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILevelPanel : MonoBehaviour
{
    #region //----> variable
    public Text levelcount;
    public Sprite activeLevel;
    public Sprite defaultLevel;
    public Image[] levelImage;
    #endregion
    #region //----> My Method;
    public void PanelUpdate()
    {
        var levelM = GameManager.ins.levelManager;
        levelcount.text = levelM.currentLevel.levelName;

        for (int i = 0; i < levelImage.Length; i++)
        {
            if ((i+1)<=levelM.currentLevel.levelNumber)
            {
                levelImage[i].sprite = activeLevel;
            }
            else
            {
                levelImage[i].sprite = defaultLevel;
            }
        }
    }
    #endregion
}

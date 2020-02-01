using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPanel : MonoBehaviour
{
    public void Finish()
    {
        RUIPanel.Open("start");
        int levelCount = GameManager.ins.currentLevel.levelNumber;
        if (levelCount+1 > GameManager.ins.levels.Count )
        {
            levelCount = 1;
        }
        else
        {
            levelCount++;
        }
        GameManager.ins.levelDataSave(levelCount);
        GameManager.ins.currentLevel = GameManager.ins.GetSaveLevel();
        GameManager.ins.LevelLoad();
        GameManager.ins.startPanel.PanelUpdate();
    }
}

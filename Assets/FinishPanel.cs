using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPanel : MonoBehaviour
{
    public void Finish()
    {
        RUIPanel.Open("start");
        var level = GameManager.ins.levelManager;
        int levelCount = level.currentLevel.levelNumber;
        if (levelCount + 1 > level.levelDatas.Count)
        {
            levelCount = 1;
        }
        else
        {
            levelCount++;
        }
        level.CurrentLevelSave(levelCount);
        level.currentLevel = level.GetLoadLevel();
        level.LevelLoad();
        GameManager.ins.uiManager.uiLevelPanel.PanelUpdate();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Level Manager Levellerin datasının tutulduğu yer ve kayıt edilip Yüklendiği yer .
/// </summary>
public class LevelManager : MonoBehaviour
{
    #region //----> Variable
    public List<LevelData> levelDatas = new List<LevelData>();
    [HideInInspector]
    public LevelData currentLevel;
    #endregion
    #region //----> Unity Level
    private void Start()
    {
        currentLevel = GetLoadLevel();
        LevelLoad();
        GameManager.ins.uiManager.uiLevelPanel.PanelUpdate();
    }
    #endregion
    #region //----> My method
    public void LevelLoad()
    {
        for (int i = 0; i < levelDatas.Count; i++)
        {
            if (currentLevel.levelNumber == levelDatas[i].levelNumber)
            {
                levelDatas[i].road.SetActive(true);
            }
            else
            {
                levelDatas[i].road.SetActive(false);
            }
        }
        GameManager.ins.car.transform.position = GameManager.ins.startPos.position;
    }

    public void CurrentLevelSave(int levelCount)
    {
        PlayerPrefs.SetInt("level", levelCount);
    }

    public LevelData GetLoadLevel()
    {
        int levelC = PlayerPrefs.GetInt("level");
        levelC = levelC < 1 ? 1 : levelC;
        var levelD = levelDatas.Find(x => x.levelNumber == levelC);
        return levelD;
    }

    #endregion

}

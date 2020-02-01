using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region //----> Variable
    public static GameManager ins;
    public GameMode currentGameMode;
    public List<LevelData> levels = new List<LevelData>();
    public LevelData currentLevel;
    public Sprite activelevel;
    public Sprite defaultLevel;
    public Text levelcount;
    public Image[] levelImage;
    public StartPanel startPanel;
    public GameObject car;
    public Transform startPos;

    #endregion
    #region //----> Unity Method
    private void Awake()
    {
        ins = this;
        currentGameMode = GameMode.stop;
        currentLevel = GetSaveLevel();
    }
    private void Start()
    {
        startPanel.PanelUpdate();
        LevelLoad();
    }
    #endregion
    #region //----> My Method
    public void LevelLoad()
    {
        for (int i = 0; i < levels.Count; i++)
        {
            if (currentLevel.levelNumber == levels[i].levelNumber)
            {
                currentLevel.road.SetActive(true);
            }
            else
            {
                levels[i].road.SetActive(false);
            }
        }
        car.transform.position = startPos.position;
    }
    public void levelDataSave(int levelCount)
    {
        PlayerPrefs.SetInt("level", levelCount);
    }
    public LevelData GetSaveLevel()
    {
        int levelCount = PlayerPrefs.GetInt("level");
        levelCount = levelCount < 1 ? 1 : levelCount;
        var levelD = levels.Find(x => x.levelNumber == levelCount);
        return levelD;
    }



    #endregion
}

public enum GameMode
{
    play,
    stop
}

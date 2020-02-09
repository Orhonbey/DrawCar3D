using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Game Manager - Oyunun Level Yöneticisi Genel Erişilmesi gerekenlere erişilecek olan Class
/// </summary>
public class GameManager : MonoBehaviour
{
    #region //----> Varaible
    public static GameManager ins;
    [HideInInspector]
    public GameMode gMode;
    public CarMachine car;
    public Transform startPos;
    public LevelManager levelManager;
    public UIManager uiManager;
    #endregion
    #region //----> Unity Method
    private void Awake()
    {
        ins = this;
        gMode = GameMode.stop;
    }
    #endregion
}

public enum GameMode
{
    play = 0,
    stop = 1
}

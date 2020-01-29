using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// FixPanel Fix panelleri Yöneten Kullanıcı Tarafından Tetkilenmesi gerekmeyen bir yapı
/// </summary>
public class RUIFixPanel : MonoBehaviour
{
    #region //----> Variable
    public static RUIFix[] fixPanels;
    #endregion
    private void Start()
    {
        fixPanels = GetComponentsInChildren<RUIFix>();
    }
    /// <summary>
    /// Panel Fixlemeye yarayan Fonksiyondur aktif edilecek olan Panel Id varilier .
    /// </summary>
    /// <param name="activePanelId">aktif edilecek olan Panel Idsi verilir .</param>
    public static void FixOpen(string activePanelId)
    {
        for (int i = 0; i < fixPanels.Length; i++)
        {
            fixPanels[i].ShotDown(activePanelId);
        }
    }
}

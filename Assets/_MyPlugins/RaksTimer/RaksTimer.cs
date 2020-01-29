/*
 * Raks Game RaksTimer.
 */
using UnityEngine;
//----> Başlangıç ta Aktifmmi yoksa pasifmi başlasın onu ayrlıyabileceğiz .
public class RaksTimer
{
    #region //----> Variable
    private float   repeatTime;
    private float   offsetTime;
    private bool    repeatBool;
    #endregion
    //---->
    public RaksTimer()
    {
        repeatBool = false;
    }
    //---->
    public bool Repeat(float time)
    {
        if (!repeatBool)
        {
            offsetTime = Time.time + time;
            repeatBool = true;
            return true;
        }
        if (Time.time >= offsetTime)
        {
            offsetTime = Time.time + time;
            return true;
        }
        return false;
    }
}

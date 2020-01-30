using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.Extensions;

public class DrawPanel : MonoBehaviour
{
    #region //----> Variable
    public RaksTouch touch;
    public UILineTextureRenderer lineRenderer;
    [HideInInspector]
    public List<Vector2> fingerPositions = new List<Vector2>();
    RaksTimer timer = new RaksTimer();
    #endregion
    #region //----> Unity Method
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (touch.isEvent)
            {
                CreateLine();
            }
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (touch.isEvent)
            {
                UpdateLine();
            }
        }
    }
    #endregion
    #region //----> My Method
    /// <summary>
    /// İlk tıklamada Oluşturulacak olan işlemleri burada belirtiyoruz .
    /// </summary>
    /// 
    public void CreateLine()
    {
        fingerPositions.Clear();
        Vector2 firstPos = lineRenderer.transform.InverseTransformPoint(touch.startPosition);
        fingerPositions.Add(firstPos);
        //lineRenderer.transform.position = touch.startPosition;
        lineRenderer.Points = fingerPositions.ToArray();
    }
    public void UpdateLine()
    {
        float dis = Vector2.Distance(fingerPositions[fingerPositions.Count - 1], touch.currentPosition);
        if (dis > 2)
        {
            Vector2 fingerPos = lineRenderer.transform.InverseTransformPoint(touch.currentPosition);
            fingerPositions.Add(fingerPos);
            lineRenderer.Points = fingerPositions.ToArray();
        }
    }

    #endregion
}

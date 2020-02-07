using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.Extensions;
using PathCreation;
using ProBuilder2.Common;
using ProBuilder2.MeshOperations;
public class DrawPanel : MonoBehaviour
{
    #region //----> Variable
    public RaksTouch touch;
    public UILineTextureRenderer lineRenderer;
    [HideInInspector]
    public List<Vector2> fingerPositions = new List<Vector2>();
    RaksTimer timer = new RaksTimer();
    public Transform mainCarT;
    public Material drawCarMaterial;
    public CarMachine carMachine;
    private GameObject drawC;
    pb_BezierShape pathObject;
    #endregion
    #region //----> Unity Method
    // Update is called once per frame
    void Update()
    {
        if (GameManager.ins.currentGameMode == GameMode.play)
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
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                if (fingerPositions.Count > 5)
                {
                    CreateDrawCar(fingerPositions);
                }
                else
                {
                    Time.timeScale = 1;
                }
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
        Time.timeScale = 0f;
        carMachine.isStart = false;
        carMachine.rb.useGravity = false;
        fingerPositions.Clear();
        Vector2 firstPos = lineRenderer.transform.InverseTransformPoint(touch.startPosition);
        fingerPositions.Add(firstPos);
        //lineRenderer.transform.position = touch.startPosition;
        lineRenderer.Points = fingerPositions.ToArray();
    }
    public void UpdateLine()
    {
        Vector2 touchCurrentPos = lineRenderer.transform.InverseTransformPoint(touch.currentPosition);
        float dis = Vector3.Distance(fingerPositions[fingerPositions.Count - 1], touchCurrentPos);
        if (dis > 75)
        {
            Vector2 fingerPos = touchCurrentPos;
            fingerPositions.Add(fingerPos);
            lineRenderer.Points = fingerPositions.ToArray();
        }
    }
    public void CreateDrawCar(List<Vector2> points)
    {
        GameObject pathObjectContainer = new GameObject();
        var pathO = pathObjectContainer.AddComponent<pb_Object>();
        var pbEntity = pathObjectContainer.GetComponent<pb_Entity>();
        pathObject = pathObjectContainer.AddComponent<pb_BezierShape>();
        List<pb_BezierPoint> pathPoints = new List<pb_BezierPoint>();
        for (int i = 0; i < points.Count; i++)
        {
            pathPoints.Add(new pb_BezierPoint(points[i], points[i], points[i], Quaternion.identity));
        }
        pathObject.m_Points = pathPoints;
        pathObject.m_Radius = 25;
        pathObject.Refresh();
        pathObjectContainer.transform.localScale = new Vector3(0.005f, 0.005f, 0.005f);
        pathO.ToMesh();
        Mesh m = pathObjectContainer.GetComponent<MeshFilter>().sharedMesh;
        MeshRenderer mR = pathObjectContainer.GetComponent<MeshRenderer>();
        MeshCollider mC = pathObjectContainer.AddComponent<MeshCollider>();
        mC.sharedMesh = m;
        mC.convex = true;
        mR.sharedMaterial = drawCarMaterial;
        if (drawC != null)
        {
            Destroy(drawC);
        }
        pathObjectContainer.transform.parent = mainCarT;
        pathObjectContainer.transform.position = mainCarT.position;
        WheelPlacement(pathObjectContainer.transform);
        drawC = pathObjectContainer;
        CarReset();
    }

    public void WheelPlacement(Transform parent)
    {
        Vector3 frontPos = pathObject.m_Points[pathObject.m_Points.Count - 1].position * parent.localScale.x;
        frontPos.z = frontPos.x;
        frontPos.x = 0;
        Vector3 backPos = pathObject.m_Points[0].position * 0.005f;
        backPos.z = backPos.x;
        backPos.x = 0;
        carMachine.frontWheels.localPosition = frontPos;
        carMachine.backWheels.localPosition = backPos;
        Time.timeScale = 1f;
    }

    private void CarReset()
    {
        carMachine.isStart = true;
        carMachine.rb.useGravity = true;
        carMachine.rb.angularVelocity = Vector3.zero;
        //carMachine.rb.rotation = 
        Vector3 carMainRot = carMachine.transform.localEulerAngles;
        carMainRot.z = 0;
        carMainRot.x = 0;
        carMachine.transform.localEulerAngles = carMainRot;
        Vector3 newCarPos = GameManager.ins.currentLevel.road.transform.position;
        newCarPos.y += 1;
        newCarPos.x = mainCarT.position.x;
        newCarPos.z = mainCarT.position.z;
        mainCarT.position = newCarPos;
        Vector3 carRot = drawC.transform.localEulerAngles;
        carRot.z = 0;
        carRot.y = -90;
        carRot.x = 0;
        drawC.transform.localEulerAngles = carRot;
    }
    #endregion
}

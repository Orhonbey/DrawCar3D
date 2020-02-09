using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishController : MonoBehaviour
{
    void Update()
    {
        if (GameManager.ins.gMode == GameMode.play)
        {
            var finishPoint = GameManager.ins.levelManager.currentLevel.finishPoint;
            float distance = transform.position.x - finishPoint.position.x;

            if (distance > 0)
            {
                GameManager.ins.gMode = GameMode.stop;
                GameManager.ins.car.rb.velocity = Vector3.zero;
                RUIPanel.Open("finish");
            }
        }
    }
}

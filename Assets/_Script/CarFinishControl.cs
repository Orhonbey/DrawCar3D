using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarFinishControl : MonoBehaviour
{
    CarMachine myMachine;

    private void Start()
    {
        myMachine = GetComponent<CarMachine>();
    }
    public void Update()
    {
        if (GameManager.ins.currentGameMode == GameMode.play)
        {
            var cLevel = GameManager.ins.currentLevel;
            float finishDistance = Vector3.Distance(transform.position, cLevel.finishPoint.position);

            if (finishDistance < 2)
            {
                GameManager.ins.currentGameMode = GameMode.stop;
                myMachine.rb.velocity = Vector3.zero;
                //myMachine.Breka();
                RUIPanel.Open("finish") ;
            }
        }
    }
}

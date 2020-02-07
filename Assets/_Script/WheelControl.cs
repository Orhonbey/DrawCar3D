using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelControl : MonoBehaviour
{
    #region //----> Variable
    [HideInInspector]
    public WheelCollider myWheelCollider;
    public GameObject myWheel;
    Vector3 wheelPos;
    Quaternion wheelRot;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        myWheelCollider = GetComponent<WheelCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        myWheelCollider.GetWorldPose(out wheelPos, out wheelRot);
        myWheel.transform.position = wheelPos;
    }
}

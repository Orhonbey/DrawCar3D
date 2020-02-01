using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMachine : MonoBehaviour
{
    #region //----> Variable
    public bool isStart;
    /// <summary>
    /// Ön tekerlekler.
    /// </summary>
    public Transform frontWheels;
    /// <summary>
    /// Arka tekerler.
    /// </summary>
    public Transform backWheels;
    [Header("Tekerler")]
    public WheelCollider[] wheelColliders;
    [HideInInspector]
    public Rigidbody rb;
    public float torquePower;
    public float power;
    #endregion
    #region //----> Unity Method
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Update()
    {
        if (isStart)
        {
            foreach (var item in wheelColliders)
            {
                item.motorTorque = Time.deltaTime * torquePower;
            }
            if (IsGround())
            {
                rb.AddForce(Vector3.right * Time.deltaTime * power, ForceMode.Acceleration);
            }
        }
    }

    private bool IsGround()
    {
        foreach (var item in wheelColliders)
        {
            if (!item.isGrounded)
            {
                return false;
            }
        }
        return true;
    }
    #endregion
}

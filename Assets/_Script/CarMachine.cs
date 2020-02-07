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
    public float carMaxSpeed = 20;
    #endregion
    #region //----> Unity Method
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void FixedUpdate()
    {
        if (GameManager.ins.currentGameMode == GameMode.play)
        {
            if (rb.velocity.magnitude < carMaxSpeed)
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
            Debug.Log("Hız : " + rb.velocity.magnitude + " : Dönüş Hızına bakılacak . " + rb.angularVelocity.magnitude);
            if (rb.angularVelocity.magnitude > 5)
            {
                rb.angularVelocity = Vector3.Lerp(rb.angularVelocity, Vector3.zero, Time.deltaTime * 10);
            }
        }
    }

    #endregion
    #region //----> My Method
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

    public void Breka()
    {
        foreach (var item in wheelColliders)
        {
            item.brakeTorque = 10;
        }
    }
    #endregion
}

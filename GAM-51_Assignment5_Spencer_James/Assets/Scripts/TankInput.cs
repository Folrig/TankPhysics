using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankInput : MonoBehaviour
{
    #region Variables
    private TankPhysics tankPhysics;
    #endregion

    #region Methods
    void Start()
    {
        tankPhysics = GetComponent<TankPhysics>();
    }

    void FixedUpdate()
    {
        if (Input.GetAxis("Vertical") > 0.0f)
        {
            foreach (WheelCollider wheel in tankPhysics.LeftWheels)
            {
                wheel.motorTorque += Input.GetAxis("Vertical") * tankPhysics.AccelerationPower;
            }
        }
        if (Input.GetAxis("Vertical") < 0.0f)
        {
            foreach (WheelCollider wheel in tankPhysics.LeftWheels)
            {
                wheel.brakeTorque += Input.GetAxis("Vertical") * tankPhysics.BrakingPower;
            }
        }
        if (Input.GetAxis("Fire1") > 0.01f)
        {
            foreach (WheelCollider wheel in tankPhysics.LeftWheels)
            {
                wheel.motorTorque += Input.GetAxis("Fire1") * tankPhysics.AccelerationPower;
            }

        }
        if (Input.GetAxis("Fire1") < 0.01f)
        {
            foreach (WheelCollider wheel in tankPhysics.LeftWheels)
            {
                wheel.brakeTorque += Input.GetAxis("Fire1") * tankPhysics.BrakingPower;
            }
        }
    }
    #endregion
}

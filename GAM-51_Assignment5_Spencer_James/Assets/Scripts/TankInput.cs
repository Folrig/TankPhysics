using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankInput : MonoBehaviour
{
    #region Variables
    public TankPhysics _tankPhysics;
    private float _rightAcceleration;
    private float _leftAcceleration;
    #endregion

    #region Properties
    public float RightAcceleration { get { return this._rightAcceleration; } }
    public float LeftAcceleration { get { return this._leftAcceleration; } }
    #endregion

    #region Methods
    void Start()
    {
        _tankPhysics = GetComponent<TankPhysics>();
    }

    // Capture input in Update
    void Update()
    {
        _rightAcceleration = Input.GetAxis("Vertical");
        _leftAcceleration = Input.GetAxis("Fire1");
    }

    // Perform physics calculations in FixedUpdate
    // brakeTorque must always be positive
    // Can be refactored to avoid duplication
    void FixedUpdate()
    {
        foreach (WheelCollider wheel in _tankPhysics.RightWheels)
        {
            wheel.motorTorque = 0f;
            wheel.motorTorque = _rightAcceleration * _tankPhysics.AccelerationPower;
        }
        foreach (WheelCollider wheel in _tankPhysics.LeftWheels)
        {
            wheel.motorTorque = 0f;
            wheel.motorTorque = _leftAcceleration * _tankPhysics.AccelerationPower;
        }
    }
    #endregion
}

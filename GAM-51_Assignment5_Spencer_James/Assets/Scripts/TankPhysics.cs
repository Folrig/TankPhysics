using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPhysics : MonoBehaviour
{
    #region Variables
    private Rigidbody rb;
    private Vector3 massOffset = new Vector3(0f, -0.25f, 0f);
    [SerializeField] private float _accelerationPower = 50f;
    [SerializeField] private List<WheelCollider> _rightWheels = new List<WheelCollider>();
    [SerializeField] private List<WheelCollider> _leftWheels = new List<WheelCollider>();
    #endregion

    #region Properties
    public float AccelerationPower { get { return this._accelerationPower; } }
    public List<WheelCollider> RightWheels { get { return this._rightWheels; } }
    public List<WheelCollider> LeftWheels { get { return this._leftWheels; } }
    #endregion

    #region Methods
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = massOffset;
    }
    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPhysics : MonoBehaviour
{
    #region Variables
    [SerializeField] private Rigidbody rb;
    private Vector3 massOffset = new Vector3(0f, -0.25f, 0f);
    public float acceleration = 0f;
    public float braking = 0f;
    public float steering = 0f;
    [SerializeField] private float enginePower = 10.0f;
    [SerializeField] private float brakingPower = 5.0f;
    #endregion

    #region Methods
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = massOffset;
	}

	void FixedUpdate()
    {
        rb.AddForce(Vector3.forward * enginePower, ForceMode.Force);
        rb.AddForce(Vector3.back * brakingPower, ForceMode.Force);
	}
    #endregion
}

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

    void Update()
    {
        tankPhysics.acceleration = Input.GetAxis("Vertical");
        tankPhysics.braking = Input.GetAxis("Jump");
        tankPhysics.steering = Input.GetAxis("Horizontal");
    }
    #endregion
}

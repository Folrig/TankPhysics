using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    #region Variables
    [SerializeField] private Transform _target;
    [SerializeField] private float _smoothingValue = 10000f;
    #endregion

    #region Methods
	void Update ()
    {
        transform.position = Vector3.Lerp(transform.position, _target.position, Time.smoothDeltaTime * _smoothingValue);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, _target.rotation.eulerAngles.y, 0), Time.smoothDeltaTime * _smoothingValue);
    }
    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleModifier : MonoBehaviour
{
    #region Variables
    private ParticleSystem _dustTrails;
    [SerializeField] private float _emissionModifier;
    [SerializeField] private WheelCollider _wheel;
    #endregion

    #region Methods
    void Start()
    {
        _dustTrails = GetComponent<ParticleSystem>();
        _wheel = GetComponentInParent<WheelCollider>();
	}

	void Update()
    {
        ParticleSystem.EmissionModule emissions = _dustTrails.emission;
        emissions.rateOverTime = _wheel.motorTorque * _emissionModifier;
	}
    #endregion
}

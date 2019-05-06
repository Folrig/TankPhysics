using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Can't get the logic for this working correctly to Lerp between moving and idling sounds

public class AudioModifier : MonoBehaviour
{
    #region Variables
    private AudioSource _tankSound;
    private TankInput _tankInput;
    private float _idleVolume = 0.2f;
    private float _idlePitch = 0.7f;
    private float _movingVolume = 0.35f;
    private float _movingPitch = 1.0f;
    public float _lerpTime = 0.0f;
    public bool _isMoving = false;
    #endregion

    #region Methods
    void Start()
    {
        _tankSound = GetComponent<AudioSource>();
        _tankInput = GetComponent<TankInput>();
	}

	void Update()
    {
        // If engines are running, lerp to desired pitch and volume
        // if not lerp from whatever they currently are to the idling pitch and volume
        _lerpTime += Time.deltaTime * 0.35f;

        if ((_tankInput.RightAcceleration <= 0.01 || _tankInput.LeftAcceleration <= 0.01) && _isMoving == true)
        {
            _lerpTime = 0.0f;
            _isMoving = false;
        }
        if ((_tankInput.RightAcceleration >= 0.01 || _tankInput.LeftAcceleration >= 0.01) && _isMoving == false)
        {
            _lerpTime = 0.0f;
            _isMoving = true;
        }

        if (_isMoving)
        {
            _tankSound.volume = Mathf.Lerp(_idlePitch, _movingVolume, _lerpTime);
            _tankSound.pitch = Mathf.Lerp(_idlePitch, _movingPitch, _lerpTime);
            _isMoving = true;
        }
        if (!_isMoving)
        {
            _tankSound.volume = Mathf.Lerp(_movingVolume, _idleVolume, _lerpTime);
            _tankSound.pitch = Mathf.Lerp(_movingPitch, _idlePitch, _lerpTime);
            _isMoving = false;
        }
	}
    #endregion
}

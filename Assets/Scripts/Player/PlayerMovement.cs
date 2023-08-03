using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _playerRigidbody;

    private float _playerSpeed;

    public float PlayerSpeed { get; private set; }

    private void FixedUpdate()
    {
        float z = Input.GetAxis("Vertical") * _playerSpeed;

        _playerRigidbody.velocity = new Vector3(_playerRigidbody.velocity.x, _playerRigidbody.velocity.y, z);
    }

    public void SetSpeed(float value)
    {
        _playerSpeed = value;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{    
    [SerializeField] private float _zOffset;
    [SerializeField] private float _smoothTime;

    private Vector3 _velocity = Vector3.zero;    

    private void FixedUpdate()
    {
        Transform player = GameController.Instance.PlayerController.PlayerPosition;

        transform.position = Vector3.SmoothDamp(transform.position,
            new Vector3(transform.position.x, transform.position.y, player.position.z - _zOffset), ref _velocity, _smoothTime);
    }
}

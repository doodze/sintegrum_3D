using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public event Action<Enemy> GotHit;   

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(LayerNames.PLAYER_LAYER_NAME))
        {
            GotHit?.Invoke(this);
        }
    }
}

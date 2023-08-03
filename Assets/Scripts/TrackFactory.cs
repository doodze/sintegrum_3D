using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackFactory : MonoBehaviour
{
    [SerializeField] private GameObject _trackPrefab;

    public GameObject GetTrackPart()
    {
        return Instantiate(_trackPrefab);
    }
}

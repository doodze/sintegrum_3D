using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private Material _material;
    [SerializeField] private Color _defaultPlayerColor;
    [SerializeField] private Vector3 _scaleStrength;
    [SerializeField] private float _scaleDuration;

    public event Action EnemyKilled;       

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(LayerNames.ENEMY_LAYER_NAME))
        {
            EnemyKilled?.Invoke();
        }
    }

    public void ChangeColorToRandom()
    {
        Color randomColor = new Color(Random.value, Random.value, Random.value);

        _material.color = randomColor;
    }

    public void ResetPosition()
    {
        transform.position = new Vector3(0, transform.position.y, 0);
    }

    public void ResetColor()
    {
        _material.color = _defaultPlayerColor;        
    }

    public void ScaleBounce()
    {
        var defaultScale = transform.localScale;

        transform.DOScale(_scaleStrength, _scaleDuration)
            .SetEase(Ease.Flash)
            .OnComplete(() => transform.DOScale(defaultScale, _scaleDuration));
    }

    private void OnDestroy()
    {
        _material.color = _defaultPlayerColor;
    }
}

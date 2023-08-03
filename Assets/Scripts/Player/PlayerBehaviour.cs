using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private PlayerView _playerView;
    [SerializeField] private PlayerMovement _playerMovement;

    private PlayerModel _playerModel;

    public event Action EnemyKilled;
    
    private void Awake()
    {
        _playerView.EnemyKilled += OnEnemyKilled;
    }

    public void Initialize(PlayerModel playerModel)
    {
        _playerModel = playerModel;        
    }

    public void StartMoving()
    {
        _playerMovement.SetSpeed(_playerModel.PlayerSpeed);
    }

    public void StopMoving()
    {
        _playerMovement.SetSpeed(0);
    }

    public void ResetPosition()
    {
        _playerView.ResetPosition();
    }

    public void ResetColor()
    {
        _playerView.ResetColor();
    }

    private void OnEnemyKilled()
    {
        _playerView.ChangeColorToRandom();
        _playerView.ScaleBounce();
        EnemyKilled?.Invoke();        
    }
}

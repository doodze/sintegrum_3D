using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerBehaviour _playerBehaviour;
    [SerializeField] private PlayerConfig _playerConfig;

    public Transform PlayerPosition => _playerBehaviour.transform;

    private void Awake()
    {
        GameController.Instance.SetPlayerController(this);
        GameController.Instance.GameStarted += OnGameStarted;
        GameController.Instance.GameEnded += OnGameEnded;

        _playerBehaviour.EnemyKilled += OnEnemyKilled;

        SetPlayerData();
    }

    private void SetPlayerData()
    {
        PlayerModel playerModel = new PlayerModel();

        playerModel.PlayerSpeed = _playerConfig.PlayerModel.PlayerSpeed;

        _playerBehaviour.Initialize(playerModel);
    }

    private void OnGameStarted()
    {
        _playerBehaviour.StartMoving();
    }

    private void OnGameEnded()
    {
        _playerBehaviour.StopMoving();
        _playerBehaviour.ResetColor();
        _playerBehaviour.ResetPosition();
    }

    private void OnEnemyKilled()
    {
        GameController.Instance.UIController.AddScore();
    }
}

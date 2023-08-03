using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoSingleton<GameController>
{
    public event Action GameStarted;
    public event Action GameEnded;

    public PlayerController PlayerController { get; private set; }
    public EnemyController EnemyController { get; private set; }    
    public UIController UIController { get; private set; }

    public void SetPlayerController(PlayerController playerController)
    {
        PlayerController = playerController;
    }

    public void SetEnemyController(EnemyController enemyController)
    {
        EnemyController = enemyController;
    }

    public void SetUIController(UIController uiController)
    {
        UIController = uiController;
    }

    public void StartGame()
    {
        GameStarted?.Invoke();
    }

    public void EndGame()
    {
        GameEnded?.Invoke();
    }

    private void ResetControllers()
    {
        PlayerController = null;
        EnemyController = null;        
        UIController = null;
    }

    private void OnDestroy()
    {
        ResetControllers();
    }
}

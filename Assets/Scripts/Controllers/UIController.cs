using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private ScoreUI _scoreUI;
    [SerializeField] private Button _startButton;    

    private void Awake()
    {
        GameController.Instance.SetUIController(this);        
        GameController.Instance.GameEnded += OnGameEnded;

        _scoreUI.ScoreLimitReached += OnScoreLimitReached;

        _startButton.onClick.AddListener(OnStartButtonClicked);        
    }

    public void AddScore()
    {
        _scoreUI.AddScore();
    }

    private void OnStartButtonClicked()
    {
        _scoreUI.Show();
        _startButton.interactable = false;
        _startButton.gameObject.SetActive(false);

        GameController.Instance.StartGame();
    }

    private void OnGameEnded()
    {
        _scoreUI.Hide();
        _scoreUI.ResetScore();
        _startButton.interactable = true;
        _startButton.gameObject.SetActive(true);
    }

    private void OnScoreLimitReached()
    {
        GameController.Instance.EndGame();
    }
}

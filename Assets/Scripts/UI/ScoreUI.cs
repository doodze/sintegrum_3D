using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private int _scoreLimit;

    private float _score = 0;

    public event Action ScoreLimitReached;

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void AddScore()
    {
        _score++;

        _scoreText.text = _score.ToString();

        if (_score >= _scoreLimit)
        {
            ScoreLimitReached?.Invoke();
        }
    }

    public void ResetScore()
    {
        _score = 0;
        _scoreText.text = "";
    }
}

using System;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    private int score = 0;

    private void Start()
    {
        scoreText.text = "Score: " + score;
        Events.ScoreChanged += AddScore;
    }

    private void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    private void OnDestroy()
    {
        Events.ScoreChanged -= AddScore;
    }
}

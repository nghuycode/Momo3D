using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text ScoreText, HighScoreText;
    public void UpdateScoreText(int score)
    { 
        ScoreText.text = "SCORE: " + score;
    }
    public void UpdateHighScoreText(int highScore)
    {
        HighScoreText.text = "HIGH SCORE: " + highScore;
    }
}

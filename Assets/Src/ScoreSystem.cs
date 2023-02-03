using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerScoreText;
    [SerializeField] private TextMeshProUGUI aiScoreText;
    private int playerScore = 0;
    private int aiScore = 0;

    public void AddPlayerScore(int score)
    {
        playerScore += score;
        playerScoreText.text = playerScore.ToString();
    }

    public void AddAiScore(int score)
    {
        aiScore += score;
        aiScoreText.text = aiScore.ToString();
    }

}

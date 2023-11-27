using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int score = 0;
    [SerializeField] private TextMeshProUGUI scoreText; 
    [SerializeField] private BalloonMovement balloon;
    [SerializeField] private int level;
    [SerializeField] private int scoreThresholdForThisLevel;
    public const int SCORE_THRESHOLD = 12;

    void Start()
    {
        balloon = BalloonMovement.FindObjectOfType<BalloonMovement>();

        level = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Current Level: " + level);
        scoreThresholdForThisLevel = SCORE_THRESHOLD * level;
    }

    void Update()
    {
        score = balloon.GetNumPopped();
        Debug.Log("Score: " + score);
        DisplayScore();
        if (score >= scoreThresholdForThisLevel)
        {
            SceneManager.LoadScene(level + 1);
        }
    }
    
    public void DisplayScore()
    {
        if (scoreText != null)
        {
            Debug.Log("Updating Score Text: " + scoreText);
            scoreText.SetText("Score: " + score);
        }
    }

   
}

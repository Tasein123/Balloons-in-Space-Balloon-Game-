using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton instance
    public TextMeshProUGUI scoreText; // Reference to the TextMeshProUGUI component for displaying the score
    private int score = 0; // Player's score
    public int scoreThresholdForNextLevel = 40; // Adjust this threshold as needed

    void Awake()
    {
        // Ensure only one instance of GameManager exists
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject); // Keep this GameObject when loading new scenes

        // Ensure scoreText is assigned in the Unity Editor
        if (scoreText == null)
        {
            Debug.LogError("ScoreText not assigned!");
        }
    }

    // Method to add points to the player's score
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();

        // Check if the score threshold for the next level is reached
        if (score >= scoreThresholdForNextLevel)
        {
            LoadNextLevel();
        }
    }

    void UpdateScoreText()
    {
        // Update the UI Text with the current score
        scoreText.text = "Score: " + score.ToString();
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        // Check if there is a next level (avoiding index out-of-range)
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.LogWarning($"No next level available. Current scene index: {currentSceneIndex}, Total scenes in build settings: {SceneManager.sceneCountInBuildSettings}");
        }
    }
}

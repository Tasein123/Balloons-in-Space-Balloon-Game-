using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ButtonFunctions : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {
    }

    public void GoToInstructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void PlayGame()
    {

        SceneManager.LoadScene("level 1");
    }

    public void MainMenu()
    {
        BalloonMovement.ResetNumPopped();

        SceneManager.LoadScene("Menu");
    }

    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }
}



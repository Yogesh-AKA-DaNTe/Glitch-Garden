using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoad : MonoBehaviour
{
    // Variable for storing current scene index
    int currentSceneIndex;

    void Start()
    {
        // Sets current scene index
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            StartCoroutine(WaitForTime());
        }
    }

    // Coroutine for waiting before loading next scene
    IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(3);
        LoadNextScene();
    }

    // Function for loading next scene
    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    // Function for reloading current scene
    public void RestartScene()
    {
        SceneManager.LoadScene(currentSceneIndex);
        Time.timeScale = 1;
    }

    // Function for loading main menu scene
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("StartScreen");
        Time.timeScale = 1;
    }

    // Function for loading options screen
    public void LoadOptionsScreen()
    {
        SceneManager.LoadScene("OptionsScreen");
    }

    // Function to quit the game
    public void QuitGame()
    {
        Application.Quit();
    }
}

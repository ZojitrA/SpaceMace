using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    GameSession gamestatus;

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(currentSceneIndex == 8)
        {
            SceneManager.LoadScene(currentSceneIndex + 2);
        }
        else
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }

    public void ReturnToStart()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameSession>().ResetGame();
    }
    public void RestartLevel()
    {
        gamestatus = FindObjectOfType<GameSession>();
        SceneManager.LoadScene(gamestatus.sceneIndex);
        FindObjectOfType<GameSession>().ResetGame();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}

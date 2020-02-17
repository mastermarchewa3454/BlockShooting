using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneCharger : MonoBehaviour
{
    int currentScene;
    public void ChangeToNextScene()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene + 1);
    }

    public void ChangeToStartScene()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameScore>().ResetGame();
    }

    public void QuitGame()
    {
        Application.Quit();
        
    }
}

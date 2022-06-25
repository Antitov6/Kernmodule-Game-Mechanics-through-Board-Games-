using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    Scene currentScene;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (currentScene.buildIndex == 0)
            {
                Application.Quit();
            }
            else
            {
                LoadMainMenu();
            }
        }
    }

    public void LoadTheGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}

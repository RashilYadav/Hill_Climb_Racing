using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        SoundScript.PlaySound("Menu_Click");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        SoundScript.PlaySound("Button");
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void QuitGame()
    {
        SoundScript.PlaySound("Menu_Click");
        Application.Quit();
    }

    public void RestartGame()
    {
        SoundScript.PlaySound("Menu_Click");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        ScoreScript.scoreVal = 0;
        GameIsPaused = false;
        Time.timeScale = 1f;
    }
}

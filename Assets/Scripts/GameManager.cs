using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private GameObject _gameOverCanvas;
    [SerializeField] private GameObject _pauseButton;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        Time.timeScale = 1f;
    }

    public void Menu()
    {
        SoundScript.PlaySound("Menu_Click");
        SceneManager.LoadScene("MainScene");
    }

    public void GameOver()
    {
        _gameOverCanvas.SetActive(true);
        _pauseButton.SetActive(false);
        
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        SoundScript.PlaySound("Menu_Click");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        _pauseButton.SetActive(true);
        ScoreScript.scoreVal = 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishScript : MonoBehaviour
{

    [SerializeField] private GameObject WinCanvas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        WinCanvas.SetActive(true);
        Time.timeScale = 0f;
    }
}

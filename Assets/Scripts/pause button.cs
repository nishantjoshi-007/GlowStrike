using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausebutton : MonoBehaviour
{
    public GameObject pauseMenu;
    private player2controller player2Control;

 
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    private void Start()
    {
        player2Control = FindObjectOfType<player2controller>();
    }
    
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;

        if (player2Control != null)
        {
            player2Control.InitializeGameMode();
        }
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        Scoremanager.ResetScores();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
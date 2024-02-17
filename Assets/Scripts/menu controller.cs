using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menucontroller : MonoBehaviour
{
    private gamemanager gameManager;

    private void Start()
    {
        // Try to find an existing GameManager in the scene (from a previous scene).
        gameManager = Object.FindAnyObjectByType<gamemanager>();

        // If there isn't one, create one.
        if (gameManager == null)
        {
            GameObject gmObject = new GameObject("GameManager");
            gameManager = gmObject.AddComponent<gamemanager>();
            DontDestroyOnLoad(gmObject);
        }
    }

    public void PlayAgainstComputer()
    {
        gameManager.currentGameMode = gamemanager.GameMode.PlayerVsComputer;

    }

    public void PlayAgainstPlayer()
    {
        gameManager.currentGameMode = gamemanager.GameMode.PlayerVsPlayer;

    }

    public void EasyDifficultyLevel()
    {
        gameManager.currentDifficultyLevel = gamemanager.DifficultyLevel.Easy;
    }

    public void MediumDifficultyLevel()
    {
        gameManager.currentDifficultyLevel = gamemanager.DifficultyLevel.Medium;
    }
    
    public void HardDifficultyLevel()
    {
        gameManager.currentDifficultyLevel = gamemanager.DifficultyLevel.Hard;
    }
}

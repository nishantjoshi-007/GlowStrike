using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    public enum GameMode
    {
        PlayerVsPlayer,
        PlayerVsComputer
    }
    public GameMode currentGameMode;

    public enum DifficultyLevel
    {
        Easy,
        Medium,
        Hard
    }
    public DifficultyLevel currentDifficultyLevel;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        gamemanager instance = Object.FindAnyObjectByType<gamemanager>();
        if (instance != this)
        {
            Destroy(gameObject);
        }
    }
}
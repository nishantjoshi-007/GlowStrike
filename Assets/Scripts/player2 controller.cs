using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2controller : MonoBehaviour
{
    private Computer computerAI;
    private Player2 player2Controller;
    private gamemanager gameManager;

    private void Start()
    {
        InitializeGameMode();
    }

    public void InitializeGameMode()
    {
        // Find the persistent GameManager in the scene
        gameManager = Object.FindAnyObjectByType<gamemanager>();

        // Get the references for the Computer and Player2 scripts attached to this object
        computerAI = GetComponent<Computer>();
        player2Controller = GetComponent<Player2>();

        // Based on the mode set in GameManager, activate the appropriate script
        if (gameManager.currentGameMode == gamemanager.GameMode.PlayerVsComputer)
        {
            computerAI.enabled = true;
            player2Controller.enabled = false;
        }
        else // PlayerVsPlayer mode
        {
            computerAI.enabled = false;
            player2Controller.enabled = true;
        }
    }
}
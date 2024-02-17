using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scoremanager : MonoBehaviour
{
    public Text player1ScoreText;
    public Text player2ScoreText;
    public GameObject endGamePopup; // Reference to the end game popup
    public Text winnerText; // Text element to display the winner
    public BallMovement ballMovement; // Reference to the BallMovement script


    // Global score variables
    public static int player1Score = 0;
    public static int player2Score = 0;

    private void Start()
    {
        UpdateDisplayedScores();
        endGamePopup.SetActive(false); // Initially hide the popup
    }

    public void player1goal()
    {
        player1Score++;
        player1ScoreText.text = player1Score.ToString();
        checkScore1();
    }

    public void player2goal()
    {
        player2Score++;
        player2ScoreText.text = player2Score.ToString();
        checkScore2();
    }

    private void checkScore1()
    {
        if (player1Score >= gamelength.gameLengthSelector)
        {
            ShowEndGamePopup("Player 1 Wins!");
        }
    }

    private void checkScore2()
    {
        if (player2Score >= gamelength.gameLengthSelector)
        {
            ShowEndGamePopup("Player 2 Wins!");
        }
    }

    private void ShowEndGamePopup(string winnerMessage)
    {
        winnerText.text = winnerMessage;
        endGamePopup.SetActive(true);
        ballMovement.StopMovement(); // Stop the ball when showing the popup
        Invoke("GoToGameOverScreen", 2f); // Delay before going to the game over screen
    }

    private void GoToGameOverScreen()
    {
        ResetScores();
        SceneManager.LoadScene("Game over");
    }

    private void UpdateDisplayedScores()
    {
        player1ScoreText.text = player1Score.ToString();
        player2ScoreText.text = player2Score.ToString();
    }

    public static void ResetScores()
    {
        player1Score = 0;
        player2Score = 0;
    }
}
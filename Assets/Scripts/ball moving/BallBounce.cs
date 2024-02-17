using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    public GameObject hitSFX;
    
    public BallMovement ballMovement;
    public Scoremanager scoremanager;

    private void Bounce (Collision2D collision)
    {
        Vector3 ballposition = transform.position;
        Vector3 racketposition = collision.transform.position;
        float racketheight = collision.collider.bounds.size.y;

        float positionX;
        if (collision.gameObject.name == "Player 1")
        {
            positionX = 1;
        }
        else
        {
            positionX = -1;
        }

        float positionY = (ballposition.y - racketposition.y) / racketheight;

        ballMovement.IncreaseHitCounter();
        ballMovement.MoveBall(new Vector2 (positionX, positionY));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player 1" || collision.gameObject.name == "Player 2")
        {
            Bounce(collision);
        }
        else if (collision.gameObject.name == "Right")
        {
            scoremanager.player1goal();
            ballMovement.player1Start = false;
            StartCoroutine(ballMovement.Launch());
        }
        else if (collision.gameObject.name == "Left")
        {
            scoremanager.player2goal();
            ballMovement.player1Start = true;
            StartCoroutine(ballMovement.Launch());
        }
        if (Backgroundmusic.playSoundEffects)
        {
            Instantiate(hitSFX, transform.position, transform.rotation);
        }
    }
}

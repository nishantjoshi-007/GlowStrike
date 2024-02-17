using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public Vector2 ballDirection;
    public float startSpeed;
    public float extraSpeed;
    public float maxExtraSpeed;

    public bool player1Start = true;

    private int hitCounter = 0;
    private gamemanager ballspeed;
    private Rigidbody2D rb;

    void Awake()
    {
        ballspeed = Object.FindAnyObjectByType<gamemanager>(); 
    }

    void Start()
    {
        switch (ballspeed.currentDifficultyLevel)
        {
            case gamemanager.DifficultyLevel.Easy:
                startSpeed *= 0.8f;
                extraSpeed *= 0.75f;
                maxExtraSpeed *= 0.75f;
                break;

           case gamemanager.DifficultyLevel.Medium:
                break;

            case gamemanager.DifficultyLevel.Hard:
                startSpeed *= 1.2f;
                extraSpeed *= 1.25f;
                maxExtraSpeed *= 1.25f;
                break;
        }

        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Launch());
    }

    private void Restartball()
    {
        rb.velocity = new Vector2 (0, 0);
        transform.position = new Vector2 (0,0);
    }

    public IEnumerator Launch()
    {
        Restartball();

        hitCounter = 0;
        yield return new WaitForSeconds(1);

        if (player1Start == true)
        {
            MoveBall(new Vector2(-1, 0));
            ballDirection = Vector2.left;
        }
        else
        {
            MoveBall(new Vector2(1, 0));
            ballDirection = Vector2.right;
        }
    }
    
    public void MoveBall(Vector2 direction)
    {
        direction = direction.normalized;
        float ballSpeed = startSpeed + hitCounter * extraSpeed;
        rb.velocity = direction * ballSpeed;
    }
 
    public void IncreaseHitCounter()
    {
        if (hitCounter * extraSpeed < maxExtraSpeed) 
        {
        hitCounter++;
        }
    }

    public void StopMovement()
    {
        rb.velocity = Vector2.zero; // Stops the ball
        StopAllCoroutines(); // Stops any running coroutines
    }

    void Update()
    {
      if (rb.transform.localPosition.x < 0) { ballDirection = Vector2.left; }
      if (rb.transform.localPosition.x > 0) { ballDirection = Vector2.right; }
    }
}
using UnityEngine;

public class Computer : MonoBehaviour
{
    public float moveSpeed;
    public float topBounds = 8.3f;
    public float bottomBounds = -8.3f;
    public Vector2 startingPos = new Vector2(7.50f, 0.0f);

    private GameObject ball;
    private Vector2 ballPos;
    private gamemanager Difficult;
    private Player1 speed;

    void Awake()
    {
        Difficult = Object.FindAnyObjectByType<gamemanager>();
        speed = Object.FindAnyObjectByType<Player1>();
    }

    void Start()
    {
        transform.localPosition = (Vector3)startingPos;

        switch (Difficult.currentDifficultyLevel)
        {
            case gamemanager.DifficultyLevel.Easy:
                moveSpeed *= 0.75f;
                break;

            case gamemanager.DifficultyLevel.Medium:
                moveSpeed = speed.racketSpeed;
                break;

            case gamemanager.DifficultyLevel.Hard:
                moveSpeed *= 1.75f;
                break;
        }
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (ball ==  null)
            ball = GameObject.FindGameObjectWithTag("ball");

        if (ball.GetComponent<BallMovement>().ballDirection == Vector2.right)
        {
            ballPos = ball.transform.localPosition;

            if (transform.localPosition.y > bottomBounds && ballPos.y < transform.localPosition.y)
            {
                transform.localPosition += new Vector3(0, -moveSpeed * Time.deltaTime, 0);
            }

            if (transform.localPosition.y < topBounds && ballPos.y > transform.localPosition.y)
            {
                transform.localPosition += new Vector3(0, moveSpeed * Time.deltaTime, 0);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketsController : MonoBehaviour
{
    public int score = 0;
    [Range(0, 10)] public int health = 3;

    public GameEvents gameEvents;

    public Rocket leftRocket;
    public Rocket rightRocket;

    [Range(0f, 4f)] public float moveAmount;

    // Start is called before the first frame update
    void Start()
    {
        gameEvents.onBallMissed.AddListener(onMissedBall);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (!(leftRocket.upIsBlocked && rightRocket.downIsBlocked))
            {
                MoveRockets(moveAmount);
            }

            leftRocket.downIsBlocked = false;
            rightRocket.upIsBlocked = false;
        }


        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (!(leftRocket.downIsBlocked || rightRocket.upIsBlocked))
            {
                MoveRockets(-1 * moveAmount);
            }

            leftRocket.upIsBlocked = false;
            rightRocket.downIsBlocked = false;
        }
    }

    private void MoveRockets(float amount)
    {
        var lma = new Vector3(0, amount, 0);
        var rma = new Vector3(0, -1 * amount, 0);
        this.leftRocket.gameObject.transform.position += lma;
        this.rightRocket.gameObject.transform.position += rma;
    }

    private void onMissedBall()
    {
        this.health--;

        if (this.health > 0)
        {
            this.gameEvents.resetGame();
            this.gameEvents.onScoreChange.Invoke();
        }
        else
        {
            this.gameEvents.onGameOver.Invoke();
        }

    }
}
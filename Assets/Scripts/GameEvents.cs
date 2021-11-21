using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameEvents : MonoBehaviour
{
    public int playerScore = 0;

    private bool isStarted = false;

    public UnityEvent onGameOver;
    public UnityEvent onScoreChange;
    public UnityEvent onBallMissed;
    public UnityEvent onBallKicked;

    public BallController ballController;
    public RocketsController rocketsController;

    void Awake()
    {
        onGameOver = new UnityEvent();
        onScoreChange = new UnityEvent();
        onBallMissed = new UnityEvent();
        onBallKicked = new UnityEvent();
    }

    private void Update()
    {
        // Reload Game
        if (Input.GetKey(KeyCode.R) && Input.GetKey(KeyCode.LeftShift))
        {
            reloadGame();
        }

        // Start the game
        if (Input.GetKey(KeyCode.Space) && !isStarted)
        {
            isStarted = true;
            ballController.kickBall();
            this.onBallKicked.Invoke();
        }
    }

    public void reloadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        this.isStarted = false;
        this.rocketsController.score = 0;
        this.rocketsController.health = 3;
        this.onScoreChange.Invoke();
    }

    public void resetGame()
    {
        this.isStarted = false;
        this.onScoreChange.Invoke();
        this.ballController.gameObject.transform.position = new Vector2(-4.775f, -1.8f);
        this.ballController.rb.velocity = new Vector2(0f, 0f);
    }
}
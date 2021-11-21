using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameEvents gameEvents;

    public Text title;
    public Text description;

    // Start is called before the first frame update
    void Start()
    {
        gameEvents.onGameOver.AddListener(showGameOver);
        gameEvents.onBallKicked.AddListener(onBallKicked);

        title.gameObject.SetActive(true);
        description.gameObject.SetActive(true);
        title.text = "PONG";
        description.text = "Press space to kick the ball";
    }

    public void showGameOver()
    {
        title.gameObject.SetActive(true);
        description.gameObject.SetActive(true);
        title.text = "Lost the game";
        description.text = "Reset the game With LeftShift + R";
    }

    public void onBallKicked()
    {
        title.gameObject.SetActive(false);
        description.gameObject.SetActive(false);
    }

    // public void onBallMissed()
    // {
    //     new WaitForSeconds(1);
    //     title.gameObject.SetActive(true);
    //     description.gameObject.SetActive(true);
    //     title.text = "Ball Missed";
    //     description.text = "You have another chance. Space to play";
    // }

    // Update is called once per frame
    void Update()
    {
    }
}
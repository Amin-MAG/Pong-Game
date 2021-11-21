using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallController : MonoBehaviour
{
    public GameEvents gameEvents;

    public Rigidbody2D rb;

    [Range(0f, 30f)] public float velocityAmount;
    [Range(0f, 1f)] public float randomAngle;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(Tags.WallUp.ToString()))
        {
            Debug.Log(this + " ball touch up wall");
            var v = MovementUtility.GetVelocityDirectionVector(rb.velocity);
            var ran = Random.Range(-randomAngle, randomAngle);
            rb.velocity = new Vector2(v.x + ran, -1 - ran) * velocityAmount;
        }

        if (other.gameObject.CompareTag(Tags.WallDown.ToString()))
        {
            Debug.Log(this + " ball touch down wall");
            var v = MovementUtility.GetVelocityDirectionVector(rb.velocity);
            var ran = Random.Range(-randomAngle, randomAngle);
            rb.velocity = new Vector2(v.x + ran, +1 - ran) * velocityAmount;
        }

        if (other.gameObject.CompareTag(Tags.RocketLeft.ToString()))
        {
            Debug.Log(this + " ball touch left rocket");
            var v = MovementUtility.GetVelocityDirectionVector(rb.velocity);
            var ran = Random.Range(-randomAngle, randomAngle);
            rb.velocity = new Vector2(+1 + ran, v.y - ran) * velocityAmount;
        }

        if (other.gameObject.CompareTag(Tags.RocketRight.ToString()))
        {
            Debug.Log(this + " ball touch right rocket");
            var v = MovementUtility.GetVelocityDirectionVector(rb.velocity);
            var ran = Random.Range(-randomAngle, randomAngle);
            rb.velocity = new Vector2(-1 + ran, v.y - ran) * velocityAmount;
        }

        if (other.gameObject.CompareTag(Tags.DangerZone.ToString()))
        {
            Debug.Log("Missed");
            this.gameEvents.onBallMissed.Invoke();
        }
    }

    public void kickBall()
    {
        var va = this.velocityAmount;
        var ran = Random.Range(-randomAngle / 2, randomAngle / 2);
        var r = (Random.Range(-1f, 1f)) > 0 ? 1 : -1;
        this.rb.velocity = new Vector2(va + ran, va * r - ran);
    }
}
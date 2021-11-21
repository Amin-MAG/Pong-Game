using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketsController : MonoBehaviour
{
    public Rocket leftRocket;
    public Rocket rightRocket;

    [Range(0f, 4f)] public float moveAmount;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            MoveRockets(moveAmount);
        }


        if (Input.GetKey(KeyCode.DownArrow))
        {
            MoveRockets(-1 * moveAmount);
        }
    }

    private void MoveRockets(float amount)
    {
        var lma = new Vector3(0, amount, 0);
        var rma = new Vector3(0, -1 * amount, 0);
        this.leftRocket.gameObject.transform.position += lma;
        this.rightRocket.gameObject.transform.position += rma;
    }
}
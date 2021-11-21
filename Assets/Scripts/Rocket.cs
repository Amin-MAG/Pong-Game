using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{

    public bool upIsBlocked = false;
    public bool downIsBlocked = false;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Tags.WallDown.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other);
        if (other.gameObject.CompareTag(Tags.WallUp.ToString()))
        {
            Debug.Log(this + "touch up wall");
            this.upIsBlocked = true;
        }
        
        if (other.gameObject.CompareTag(Tags.WallDown.ToString()))
        {
            Debug.Log(this + "touch down wall");
            this.downIsBlocked = true;
        }
    }
}

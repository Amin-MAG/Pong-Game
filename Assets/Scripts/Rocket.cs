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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(Tags.WallUp.ToString()))
        {
            this.upIsBlocked = true;
        }
        
        if (other.gameObject.CompareTag(Tags.WallDown.ToString()))
        {
            this.downIsBlocked = true;
        }
    }
}

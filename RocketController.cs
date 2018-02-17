﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour {
    Rigidbody2D myRb;
    public float Rocketspeed;

	// Use this for initialization
	void Awake () {
        myRb = GetComponent<Rigidbody2D>();
        if (transform.localRotation.z > 0)
        {
            myRb.AddForce(new Vector2(-1, 0) * Rocketspeed, ForceMode2D.Impulse);
        }
        else
        {
            myRb.AddForce(new Vector2(1, 0) * Rocketspeed, ForceMode2D.Impulse);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void removeForce()
    {
        myRb.velocity = new Vector2(0, 0);
    }
}

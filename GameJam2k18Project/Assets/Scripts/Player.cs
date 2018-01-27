using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Robot
{
	// Use this for initialization
	void Start ()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        speed = 3f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        MoveLeftRight();
    }
}

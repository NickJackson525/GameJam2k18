using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Robot
{
	// Use this for initialization
	protected override void Start ()
    {
        base.Start();
        speed = 3f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        MoveLeftRight();
    }
}

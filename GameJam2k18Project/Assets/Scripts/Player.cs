using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Robot
{
    Vector2 prevPos;
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
        prevPos=transform.position;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.position = prevPos;
    }
}

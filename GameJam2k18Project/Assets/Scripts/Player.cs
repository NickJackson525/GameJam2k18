using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Robot
{
    Vector2 prevPos;
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
        prevPos=transform.position;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.position = prevPos;
    }
}

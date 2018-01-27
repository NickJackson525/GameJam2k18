using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : Robot
{
    Vector3 dir = Vector3.right;
    BoxCollider2D coll;

	// Use this for initialization
	void Start ()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        isGrounded = true;
    }
	
	// Update is called once per frame
	void Update()
    {
        MoveLeftRight();
    }

    //grounded checking
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        if (rigidbody.velocity.y == 0)
        {
            isGrounded = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //print("Isgrounded");
        isGrounded = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //print("isnotgrounded");
        isGrounded = false;
    }

}


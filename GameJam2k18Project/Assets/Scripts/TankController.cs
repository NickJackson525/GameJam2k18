using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : Robot
{
    Vector3 dir = Vector3.right;
    BoxCollider2D coll;

	// Use this for initialization
	protected override void Start ()
    {
        base.Start();
        coll = GetComponent<BoxCollider2D>();
        isGrounded = true;
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (isSelected)
        {
            base.Update();
            MoveLeftRight();
        }
    }

    //grounded checking
    private void OnCollisionStay2D(Collision2D collision)
    {
        //print("Isgrounded");
        isGrounded = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        //print("isnotgrounded");
        isGrounded = false;
    }

}


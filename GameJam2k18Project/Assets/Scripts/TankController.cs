using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : Robot {

    [SerializeField]
    float speed = 1f;
    [SerializeField]
    float jumpHeight;
    Vector3 dir = Vector3.right;
    BoxCollider2D coll;
    Rigidbody2D rigidbody;
    [SerializeField]
    bool isGrounded;
	// Use this for initialization
	void Start () {
        coll = GetComponent<BoxCollider2D>();
        rigidbody = GetComponent<Rigidbody2D>();

        isSelected = true;
        isGrounded = true;
    }
	
	// Update is called once per frame
	void Update() {
        
        if (isSelected)
    {
            if (Input.GetKey(KeyCode.A))
            {
                rigidbody.velocity = new Vector2(-speed, rigidbody.velocity.y);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                rigidbody.velocity = new Vector2(speed, rigidbody.velocity.y);
            }
            else
            {
                rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
            }

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpHeight);
            }
        }
    else
        { 
            //AI here
    }
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


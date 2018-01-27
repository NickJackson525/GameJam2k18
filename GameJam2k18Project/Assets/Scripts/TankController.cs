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
	// Use this for initialization
	void Start () {
        coll = GetComponent<BoxCollider2D>();
        rigidbody = GetComponent<Rigidbody2D>();
        

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

            if (Input.GetKeyDown(KeyCode.Space))
            {
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpHeight);
            }
        }
    else
        { 
            //AI here
    }
  }
		
	}


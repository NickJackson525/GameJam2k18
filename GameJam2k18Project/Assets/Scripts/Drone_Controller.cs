using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone_Controller : Robot {
    [SerializeField]
    Vector2 moveS=new Vector2(3,0);
    Vector2 moveV = new Vector2(0, 3);
    Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (isSelected)
        {
            if (Input.GetKey(KeyCode.A)&& rb.velocity.x > -moveS.x)
            {
                rb.velocity -= (moveS/5) / 2;
            }
            if (Input.GetKey(KeyCode.D)&& rb.velocity.x < moveS.x)
            {
                rb.velocity += (moveS/5) / 2;
            }
            if (Input.GetKey(KeyCode.W)&& rb.velocity.y < moveV.y/1.5)
            {
                rb.velocity += (moveV/6) / 2;
            }
            if (Input.GetKey(KeyCode.S)&& rb.velocity.y > -moveV.y)
            {
                rb.velocity -= (moveV/7) / 2;
            }
        }
    }
}

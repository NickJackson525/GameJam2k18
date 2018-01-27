using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    public bool isSelected { get; set; }
    protected bool isGrounded;
    protected float speed = 1f;
    protected float jumpHeight = 3f;
    protected Rigidbody2D rigidbody;
    Vector2 moveV = new Vector2(0, 3);

    private void Start()
    {
        
    }

    private void Update()
    {

    }

    protected virtual void MoveLeftRight()
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
    }

    protected virtual void MoveUpDown()
    {
        if (Input.GetKey(KeyCode.W) && rigidbody.velocity.y < moveV.y / 1.5)
        {
            rigidbody.velocity += (moveV / 6) / 2;
        }
        if (Input.GetKey(KeyCode.S) && rigidbody.velocity.y > -moveV.y)
        {
            rigidbody.velocity -= (moveV / 7) / 2;
        }
    }

    protected virtual void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpHeight);
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player" && gameObject.tag != "Player")
        {
            Destroy(coll.gameObject);
            gameObject.tag = "Player";
            isSelected = true;
        }
    }
}

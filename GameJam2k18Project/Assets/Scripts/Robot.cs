using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Robot : MonoBehaviour
{
    public bool isSelected { get; set; }
    protected bool isGrounded;
    protected float speed = 1f;
    protected float jumpHeight = 3f;
    protected Rigidbody2D rb;
    Vector2 moveV = new Vector2(0, 3);

    [SerializeField]
    private List<Transform> pathNodes;
    [SerializeField]
    private float pathDistanceTillNext;
    [SerializeField]
    private bool pathSnap;
    [SerializeField]
    private float pathSpeed = 3f;

    protected int pathIndex = 0;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

    }

    protected virtual void MoveLeftRight()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    protected virtual void MoveUpDown()
    {
        if (Input.GetKey(KeyCode.W) && rb.velocity.y < moveV.y / 1.5)
        {
            rb.velocity += (moveV / 6) / 2;
        }
        if (Input.GetKey(KeyCode.S) && rb.velocity.y > -moveV.y)
        {
            rb.velocity -= (moveV / 7) / 2;
        }
    }

    protected virtual void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player" && gameObject.tag != "Player" && gameObject.tag != "WifiPoint")
        {
            Destroy(coll.gameObject);
            gameObject.tag = "Player";
            isSelected = true;
        }
    }

    protected void FollowPath()
    {
        if (pathIndex < pathNodes.Count)
        {
            if (Vector3.Distance(this.gameObject.transform.position, pathNodes[pathIndex].position) > pathDistanceTillNext)
            {
                Vector3 direction = (pathNodes[pathIndex].position - this.gameObject.transform.position).normalized;
                rb.AddForce(new Vector2(direction.x, direction.y) * pathSpeed);
            }
            else
            {
                if (pathSnap)
                {
                    this.gameObject.transform.position = pathNodes[pathIndex].position;
                }
                rb.velocity = Vector3.zero;
                pathIndex++;
            }
        }
        else
        {
            pathIndex = 0;
        }
    }
}

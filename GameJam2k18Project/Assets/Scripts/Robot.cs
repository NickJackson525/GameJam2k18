using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Robot : MonoBehaviour
{
    public GameObject terminalSpark;
    protected GameObject createdSpark;

    public bool isSelected { get; set; }
    protected bool isGrounded;
    bool sendingSpark;
    protected float speed = 1f;
    protected float jumpHeight = 3f;
    protected Rigidbody2D rb;
    Vector2 moveV = new Vector2(0, 3);

    [Header("Pathing")]
    [SerializeField]
    protected List<Transform> pathNodes;
    [SerializeField]
    protected float pathDistanceTillNext;
    [SerializeField]
    protected bool pathSnap;
    [SerializeField]
    protected float pathSpeed = 3f;

    [Header("Combat")]
    [SerializeField]
    protected float aggroDistance = 5f;
    [SerializeField]
    protected float health = 50f;

    public float Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
        }
    }

    protected int pathIndex = 0;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    {
        if (isSelected && !sendingSpark && Input.GetMouseButtonUp(0))
        {
            sendingSpark = true;
            createdSpark = Instantiate(terminalSpark, transform.position, transform.rotation);
            createdSpark.GetComponent<PlayerFromTerminal>().targetPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            createdSpark.GetComponent<PlayerFromTerminal>().targetPoint = new Vector3(createdSpark.GetComponent<PlayerFromTerminal>().targetPoint.x, createdSpark.GetComponent<PlayerFromTerminal>().targetPoint.y, 0);
            createdSpark.GetComponent<PlayerFromTerminal>().startPoint = transform.position;
            createdSpark.GetComponent<PlayerFromTerminal>().timer = 100;
            createdSpark.tag = "Spark";
            gameObject.tag = "WifiPoint";
        }

        if (sendingSpark)
        {
            if (!createdSpark || createdSpark.GetComponent<PlayerFromTerminal>().returnHome)
            {
                if (gameObject.tag != "Player")
                {
                    gameObject.tag = "Robot";
                    sendingSpark = false;
                    isSelected = false;
                }
            }
        }

        if (!createdSpark)
        {
            if (sendingSpark || gameObject.tag != "Player")
            {
                gameObject.tag = "Robot";
                sendingSpark = false;
                isSelected = false;
            }
        }
    }

    protected virtual void MoveLeftRight()
    {
        if (!sendingSpark)
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
    }

    protected virtual void MoveUpDown()
    {
        if (!sendingSpark)
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
        if (coll.gameObject.tag == "Spark" && gameObject.tag != "Player" && gameObject.tag != "WifiPoint")
        {
            Destroy(coll.gameObject);
            gameObject.tag = "Player";
            isSelected = true;
        }
    }

    protected void FollowPath()
    {
        if(pathNodes.Count == 0)
        {
            Debug.Log("Warning: " + this.gameObject.name + " does not have a path set up. Cannot follow null path.");
            return;
        }

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone_Controller : Robot {
    [SerializeField]
    private List<Transform> pathNodes;
    [SerializeField]
    private float pathDistanceTillNext;
    [SerializeField]
    private bool pathSnap;
    [SerializeField]
    private float droneSpeed;

    Vector2 moveS=new Vector2(3,0);
    Vector2 moveV = new Vector2(0, 3);

    private int pathIndex = 0;

    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
        speed = 3;
    }
	
	// Update is called once per frame
	void Update () {
        if (isSelected)
        {
            MoveUpDown();
            MoveLeftRight();
        }
        else
        {
            FollowPath();
        }
    }

    private void FollowPath()
    {
        if(pathIndex < pathNodes.Count)
        {
            if(Vector3.Distance(this.gameObject.transform.position, pathNodes[pathIndex].position) > pathDistanceTillNext)
            {
                Vector3 direction = (pathNodes[pathIndex].position - this.gameObject.transform.position).normalized;
                rigidbody.AddForce(new Vector2(direction.x, direction.y) * droneSpeed);
            }
            else
            {
                if(pathSnap)
                {
                    this.gameObject.transform.position = pathNodes[pathIndex].position;
                }
                rigidbody.velocity = Vector3.zero;
                pathIndex++;
            }
        }
        else
        {
            pathIndex = 0;
        }
    }
}

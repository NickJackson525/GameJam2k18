using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool onVerticalWire = false;
    public bool onHorizontalWire = true;
    Vector3 previousPosition;
    int delay = 20;

	// Use this for initialization
	void Start ()
    {
        previousPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(delay > 0)
        {
            delay--;

            if(delay == 0)
            {
                previousPosition = transform.position;
                delay = 20;
            }
        }

        if (onVerticalWire)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - .1f, transform.position.z);
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + .1f, transform.position.z);
            }
        }
        else if(onHorizontalWire)
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.position = new Vector3(transform.position.x - .1f, transform.position.y, transform.position.z);
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.position = new Vector3(transform.position.x + .1f, transform.position.y, transform.position.z);
            }
        }

        if (transform.position.x > Screen.width)
        {
            transform.position = new Vector3(Screen.width, transform.position.y, transform.position.z);
        }

        if (transform.position.y > Screen.height)
        {
            transform.position = new Vector3(transform.position.x, Screen.height, transform.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "HorizontalWire")
        {
            onHorizontalWire = true;
        }

        if (coll.gameObject.tag == "VerticalWire")
        {
            onVerticalWire = true;
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "HorizontalWire")
        {
            onHorizontalWire = false;

            if (!onVerticalWire)
            {
                transform.position = previousPosition;
            }
        }

        if (coll.gameObject.tag == "VerticalWire")
        {
            onVerticalWire = false;

            if (!onHorizontalWire)
            {
                transform.position = previousPosition;
            }
        }
    }
}

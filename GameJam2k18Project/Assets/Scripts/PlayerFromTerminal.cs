using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFromTerminal : MonoBehaviour
{
    public Vector3 targetPoint;
    public Vector2 startPoint;
    public int timer = 0;
    public bool returnHome = false;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(timer > 0)
        {
            timer--;

            if(timer == 0)
            {
                returnHome = true;
            }
        }

        if(!returnHome)
        {
            transform.position = Vector3.Slerp(transform.position, targetPoint, .05f);
        }
        else
        {
            transform.position = Vector3.Slerp(transform.position, startPoint, .2f);
        }
	}
}

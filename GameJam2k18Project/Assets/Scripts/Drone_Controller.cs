using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone_Controller : Robot {
    Vector2 moveS=new Vector2(3,0);

    // Use this for initialization
    protected override void Start () {
        base.Start();
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
}

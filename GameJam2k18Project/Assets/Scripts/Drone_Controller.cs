using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone_Controller : Robot
{
    //public GameObject terminalSpark;
    Vector2 moveS=new Vector2(3,0);

    // Use this for initialization
    protected override void Start () {
        base.Start();
        speed = 3;
    }

    // Update is called once per frame
    protected override void Update ()
    {
        if (isSelected)
        {
            base.Update();
            MoveUpDown();
            MoveLeftRight();
        }
        else
        {
            FollowPath();
        }
    }
}

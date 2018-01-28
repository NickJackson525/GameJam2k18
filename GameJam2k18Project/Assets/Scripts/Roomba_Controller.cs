using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roomba_Controller : Robot
{
    protected override void Start()
    {
        base.Start();
        speed = 3;
    }
    protected override void Update()
    {
        if (isSelected)
        {
            base.Update();
            MoveLeftRight();
        }
        else
        {
            FollowPath();
        }
    }
}
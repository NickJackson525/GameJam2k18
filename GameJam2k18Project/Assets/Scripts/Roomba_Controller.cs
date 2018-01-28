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
    private void Update()
    {
        if (isSelected)
            MoveLeftRight();
        else
            FollowPath();
    }
}
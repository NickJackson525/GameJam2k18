using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roomba_Controller : Robot
{
    private void Start()
    {
        base.Start();
    }

    private void Update()
    {
        MoveLeftRight();
    }
}
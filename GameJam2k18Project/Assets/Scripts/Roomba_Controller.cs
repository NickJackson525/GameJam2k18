﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roomba_Controller : Robot
{
  // Use this for initialization
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    if (isSelected)
    {
      if (Input.GetKey(KeyCode.A))
      {
        transform.position += Vector3.left * Time.deltaTime;

      }
      if (Input.GetKey(KeyCode.D))
      {
        transform.position += Vector3.right * Time.deltaTime;
      }
    }
  }
}

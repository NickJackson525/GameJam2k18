using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roomba_Controller : Robot
{
  [SerializeField] float Speed = 1f;
  BoxCollider2D coll;
  [SerializeField] Vector3 dir = Vector3.right;
  void Start()
  {
    coll = GetComponent<BoxCollider2D>();
  }

  // Update is called once per frame
  void Update()
  {
    if (isSelected)
    {
      if (Input.GetKey(KeyCode.A))
      {
        transform.position += Vector3.left * Time.deltaTime * Speed;

      }
      if (Input.GetKey(KeyCode.D))
      {
        transform.position += Vector3.right * Time.deltaTime * Speed;
      }
    }
    else
    {
      Vector3 vec = coll.bounds.extents;
      vec.y = -vec.y;
      vec.x *= Mathf.Sign(dir.x);
      Debug.DrawRay(transform.position + vec, -transform.up, Color.red, 1f);
      RaycastHit2D inf = Physics2D.Raycast(transform.position + vec, -transform.up);
      if (inf.transform != null)
      {
        transform.position += dir * Time.deltaTime * Speed;
      }
      else
      {
        dir *= -1;
        transform.position += dir * Time.deltaTime * Speed;
      }
    }
  }
}

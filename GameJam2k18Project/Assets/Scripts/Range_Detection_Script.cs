using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range_Detection_Script : MonoBehaviour {
  CircleCollider2D coll;
  Camera_Controller ctrller;
	// Use this for initialization
	void Start () {
    coll = GetComponent<CircleCollider2D>();
    ctrller = transform.parent.GetComponent<Camera_Controller>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.E)){
      ContactFilter2D fil = new ContactFilter2D();
      fil.ClearLayerMask();
      Collider2D[] gatheredColl = new Collider2D[16];
      coll.OverlapCollider(fil, gatheredColl);
      foreach (Collider2D col in gatheredColl){
        if (col.transform != null && col.transform.tag == "Robot"){
          ctrller.SetTarget(col.transform);
          col.transform.GetComponent<Robot>().IsSelected = true;
          break;
        }
      }
    }
	}
}

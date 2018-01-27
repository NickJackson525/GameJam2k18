using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour {

  [SerializeField] Transform playerTransform;
	void Start () {
    playerTransform = GameObject.FindGameObjectWithTag("Start").transform;
	}

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.Mouse0)) {
      Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
      RaycastHit2D inf = Physics2D.Raycast(r.origin, r.direction);
      if (inf.transform != null && (inf.transform.tag == "WifiPoint" || inf.transform.tag == "Start")){
        playerTransform = inf.transform;
      }
    }
  }

  private void LateUpdate()
  {
    Vector3 tarPos = playerTransform.position;
    tarPos.z = transform.position.z;
    transform.position = Vector3.Lerp(transform.position, tarPos, .15f);
  }
}

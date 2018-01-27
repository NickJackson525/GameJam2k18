using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{

  [SerializeField] Transform playerTransform;
  [SerializeField] float jumpRangeLimit = 5f;
  [SerializeField] int rangeUpgradeLevel = 0, delayUpgradeLevel = 0;
  int[] rangeUpgrades = { 0, 3, 6, 9, 12 };
  float[] delayUpgrades = { 0f, .05f, .15f, .25f, .4f };

  bool chargingJump = false;

  void Start()
  {
    playerTransform = GameObject.FindGameObjectWithTag("Start").transform;
  }

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.Mouse0))
    {
      Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
      RaycastHit2D inf = Physics2D.Raycast(r.origin, r.direction);
      if (!chargingJump && inf.transform != null && (inf.transform.tag == "WifiPoint" || inf.transform.tag == "Start" || inf.transform.tag == "Wires") && Vector2.Distance(inf.transform.position, playerTransform.position) < jumpRangeLimit + rangeUpgrades[rangeUpgradeLevel])
      {
        if (playerTransform.tag != "Wires" || playerTransform.transform.GetComponent<Wiring_Script>().GetNeighborCount() == 1)
        {
          StartCoroutine(ChargeJump(inf.transform));
        }
        else
        {
          print("Can't jump from mid cable!");
        }
      }
    }
    else if (playerTransform.tag == "Wires")
    {
      if (Input.GetKeyDown(KeyCode.W))
      {
        Transform t = playerTransform.GetComponent<Wiring_Script>().GetNeighbor("top");
        if (t != null)
        {
          playerTransform = t;
        }
      }
      if (Input.GetKeyDown(KeyCode.S))
      {
        Transform t = playerTransform.GetComponent<Wiring_Script>().GetNeighbor("bottom");
        if (t != null)
        {
          playerTransform = t;
        }

      }
      if (Input.GetKeyDown(KeyCode.D))
      {
        Transform t = playerTransform.GetComponent<Wiring_Script>().GetNeighbor("right");
        if (t != null)
        {
          playerTransform = t;
        }

      }
      if (Input.GetKeyDown(KeyCode.A))
      {
        Transform t = playerTransform.GetComponent<Wiring_Script>().GetNeighbor("left");
        if (t != null)
        {
          playerTransform = t;
        }

      }
    }
  }

  private void LateUpdate()
  {
    Vector3 tarPos = playerTransform.position;
    tarPos.z = transform.position.z;
    transform.position = Vector3.Lerp(transform.position, tarPos, .15f);
  }

  private IEnumerator ChargeJump(Transform target)
  {
    chargingJump = true;
    yield return new WaitForSeconds(.8f - delayUpgrades[delayUpgradeLevel]);
    playerTransform = target;
    chargingJump = false;
  }
}

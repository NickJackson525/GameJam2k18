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
      if (!chargingJump && inf.transform != null && (inf.transform.tag == "WifiPoint" || inf.transform.tag == "Start") && Vector2.Distance(inf.transform.position, playerTransform.position) < jumpRangeLimit + rangeUpgrades[rangeUpgradeLevel])
      {
        print("Jumping to " + inf.transform.name);
        StartCoroutine(ChargeJump(inf.transform));
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
    print("Charging to " + target.name);
    playerTransform = target;
    chargingJump = false;
  }
}

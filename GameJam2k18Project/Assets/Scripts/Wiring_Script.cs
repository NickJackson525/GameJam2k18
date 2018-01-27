using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wiring_Script : MonoBehaviour
{
  Dictionary<string, Wiring_Script> wires;
  // Use this for initialization
  void Start()
  {
    wires = new Dictionary<string, Wiring_Script>();
    List<Wiring_Script> adjWires = new List<Wiring_Script>();
    CircleCollider2D coll = gameObject.AddComponent<CircleCollider2D>();
    Collider2D[] collection = new Collider2D[16];
    ContactFilter2D fil = new ContactFilter2D();
    fil.ClearLayerMask();
    coll.radius = .6f;
    coll.isTrigger = true;
    coll.OverlapCollider(fil, collection);
    wires.Clear();

    foreach (Collider2D obj in collection)
    {
      if (obj != null && obj.transform.tag == "Wires")
      {
        adjWires.Add(obj.GetComponent<Wiring_Script>());
      }
    }

    foreach (Wiring_Script scr in adjWires)
    {
      Vector3 val = scr.transform.position - transform.position;
      int x = (int)Mathf.Round(val.x);
      int y = (int)Mathf.Round(val.y);
      switch (x)
      {
        case (-1):
          wires.Add("left", scr);
          break;
        case (1):
          wires.Add("right", scr);
          break;
        default:
          switch (y)
          {
            case (-1):
              wires.Add("bottom", scr);
              break;
            case (1):
              wires.Add("top", scr);
              break;
          }
          break;
      }
    }

    Destroy(coll);
  }

  public Transform GetNeighbor(string str)
  {
    Wiring_Script val = null;
    wires.TryGetValue(str, out val);
    if (val != null)
    {
      return val.transform;
    }
    return null;
  }

  public int GetNeighborCount()
  {
    return wires.Count;
  }
}

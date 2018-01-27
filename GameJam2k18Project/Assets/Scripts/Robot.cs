using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
  protected bool isSelected = false;
  public bool IsSelected
  {
    get
    {
      return isSelected;
    }

    set
    {
      isSelected = value;
    }
  }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private void OnMouseEnter()
    {
        Audio_Manager.Instance.PlaySound(2f, Audio_Manager.Sound.ButtonHover);
    }
}

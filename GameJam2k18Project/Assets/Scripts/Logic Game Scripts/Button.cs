using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    public bool state;

	// Use this for initialization
	void Start () {
        state = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (state)
        {
            this.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
        }
        else
        {
            this.GetComponent<SpriteRenderer>().color = new Color32(150, 150, 150, 255);
        }
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    public bool testing = false;

    float testtimer = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(testtimer > 0)
        {
            testing = false;
            testtimer = 0;
        }
		if (testing)
        {
            testtimer += Time.deltaTime;
        }
	}

    private void OnMouseDown()
    {
        testing = true;
    }
}

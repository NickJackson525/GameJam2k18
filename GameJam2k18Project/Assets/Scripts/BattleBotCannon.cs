using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleBotCannon : MonoBehaviour {
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        GameObject target = GameObject.FindGameObjectWithTag("Player");
        gameObject.transform.eulerAngles = new Vector3(0, 0, Vector3.Angle(target.transform.position, gameObject.transform.position)+90);
    }
}

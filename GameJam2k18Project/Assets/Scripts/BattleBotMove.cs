using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleBotMove : MonoBehaviour {
    Rigidbody2D RB;
    SpriteRenderer spriteDir;

	// Use this for initialization
	void Start () {
        RB = gameObject.GetComponent<Rigidbody2D>();
        spriteDir = gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (RB.velocity.x>0&& spriteDir.flipX == true)
        {
            spriteDir.flipX = false;
        }
        else if(RB.velocity.x < 0 && spriteDir.flipX == false)
        {
            spriteDir.flipX = true;
        }
	}
}

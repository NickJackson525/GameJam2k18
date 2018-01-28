using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WirelessTerminal : Robot
{
    public GameObject terminalSpark;
    GameObject createdSpark;
    public Sprite terminalOn;
    public Sprite terminalOff;
    public bool sendingPlayer;

	// Update is called once per frame
	void Update ()
    {
        if (isSelected)
        {
            GetComponent<SpriteRenderer>().sprite = terminalOn;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = terminalOff;
        }

        if (isSelected && !sendingPlayer && Input.GetMouseButtonUp(0))
        {
            sendingPlayer = true;
            createdSpark = Instantiate(terminalSpark, transform.position, transform.rotation);
            createdSpark.GetComponent<PlayerFromTerminal>().targetPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            createdSpark.GetComponent<PlayerFromTerminal>().targetPoint = new Vector3(createdSpark.GetComponent<PlayerFromTerminal>().targetPoint.x, createdSpark.GetComponent<PlayerFromTerminal>().targetPoint.y, 0);
            createdSpark.GetComponent<PlayerFromTerminal>().startPoint = transform.position;
            createdSpark.GetComponent<PlayerFromTerminal>().timer = 300;
            createdSpark.tag = "Player";
            gameObject.tag = "WifiPoint";
            isSelected = false;
        }

        if(sendingPlayer)
        {
            if(!createdSpark || createdSpark.GetComponent<PlayerFromTerminal>().returnHome)
            {
                if (gameObject.tag != "Player")
                {
                    gameObject.tag = "Robot";
                    sendingPlayer = false;
                }
            }
        }

        if (!createdSpark)
        {
            if (sendingPlayer || gameObject.tag != "Player")
            {
                gameObject.tag = "Robot";
                sendingPlayer = false;
            }
        }
    }
}

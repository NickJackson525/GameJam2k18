using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminal_Easter_Egg : MonoBehaviour {

    [SerializeField]
    GameObject DrTCanvas;

    CanvasGroup drTOpacity;

    float timeChange;

    public bool burningTeddyBool;

	// Use this for initialization
	void Start () {

        drTOpacity = DrTCanvas.GetComponent<CanvasGroup>();
        drTOpacity.alpha = 0f;

	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.T))
        {
            burningTeddyBool = true;
        }

        //changes opacity of dr T for a set period of time
        if (burningTeddyBool == true)
        {
            timeChange += Time.deltaTime;
            if (timeChange < 1)
            {
                DrTFadeIn();
            }
            if (timeChange > 2)
            {
                DrTFadeOut();
                if (drTOpacity.alpha <= 0)
                {
                    burningTeddyBool = false;
                    timeChange = 0f;
                }
            }
        }

    }


    public void DrTFadeIn()
    {
        if (drTOpacity.alpha <= 1)
        {
            drTOpacity.alpha += 0.05f;
        }
    }

    public void DrTFadeOut()
    {
        if (drTOpacity.alpha >= 0)
        {
            drTOpacity.alpha -= 0.05f;
        }
    }
}


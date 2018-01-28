using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LogicManager : MonoBehaviour {

    [SerializeField]
    GameObject button1;
    [SerializeField]
    GameObject button2;
    [SerializeField]
    GameObject button3;

    float timer = 0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
        if (button1.GetComponent<Button>().state && button2.GetComponent<Button>().state
            && button3.GetComponent<Button>().state)
        {
            timer += Time.deltaTime;
            if(timer > 1.5f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }

        }
        else if(button1.GetComponent<Button>().state == false && button2.GetComponent<Button>().state == false
            && button3.GetComponent<Button>().state)
        {

        }

	}
}

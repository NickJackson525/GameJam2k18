﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraTracking : MonoBehaviour
{
    [SerializeField]
    [Range(0f, 1f)]
    [Tooltip("How far the camera lags behind its target. 0 = no follow, 1 = instantly snap to position")]
    private float followStep = 0.1f;
    [SerializeField]
    [Tooltip("Offset from target position")]
    private Vector3 followOffset = new Vector3(0, 0, -10); // offset from target position

    private GameObject target;

    private void Start()
    {
        StartCoroutine(TargetPlayer());
    }

    private void Update()
    {
        Audio_Manager.Instance.Update();

        if(Input.GetKeyUp(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if(Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene("Main");
        }
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            this.gameObject.transform.position = Vector3.Lerp(this.gameObject.transform.position, target.transform.position + followOffset, followStep);
        }
    }

    IEnumerator TargetPlayer()
    {
        while(true)
        {
            if (GameObject.FindGameObjectsWithTag("Player").Length > 1)
            {
                yield return new WaitForSeconds(0.5f);
            }
            else
            {
                target = GameObject.FindGameObjectWithTag("Player");
                if(target == null)
                {
                    target = GameObject.Find("Player");
                }
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    [SerializeField]
    [Range(0f, 1f)]
    private float followStep;
    [SerializeField]
    private Vector3 followOffset; // offset from target position
    private GameObject target;

    private void Start()
    {
        StartCoroutine(TargetPlayer());
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
            target = GameObject.FindGameObjectWithTag("Player");
            yield return new WaitForSeconds(0.5f);
        }
    }
}
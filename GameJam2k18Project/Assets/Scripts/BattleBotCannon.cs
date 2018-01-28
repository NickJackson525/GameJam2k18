using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleBotCannon : MonoBehaviour {
    bool inRange = false;
    int fireTime=0;
    [SerializeField]
    int shootTime=20;
    [SerializeField]
    [Tooltip("The projectile to fire")]
    private GameObject projectilePrefab; // projectile to fire (prefab)
    [SerializeField]
    [Tooltip("The projectile speed")]
    private float projectileSpeed; // projectile speed
    [SerializeField]
    [Tooltip("Where the projectile spawns from")]
    private Transform projectileSpawn; // where the projectile spawns from
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (inRange)
        {
            GameObject target = GameObject.FindGameObjectWithTag("Player");
            if (target != null)
            {
                Vector3 trackDirection = this.gameObject.transform.position - target.transform.position;
                this.gameObject.transform.localEulerAngles = new Vector3(
                    this.gameObject.transform.localEulerAngles.x,
                    this.gameObject.transform.localEulerAngles.y,
                    Mathf.Atan2(trackDirection.y, trackDirection.x) * 80 - 180);
                if (fireTime > shootTime)
                {
                    fireTime = 0;
                    Fire();
                }
                else
                {
                    fireTime++;
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            inRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inRange = false;
        }
    }
    private void Fire()
    {
        GameObject projectile = Instantiate(projectilePrefab);
        projectile.transform.position = projectileSpawn.position;
        projectile.transform.rotation = this.gameObject.transform.rotation;
        Vector3 velocityDir = (projectile.transform.right).normalized;
        projectile.GetComponent<Rigidbody2D>().AddForce(new Vector2(velocityDir.x, velocityDir.y) * projectileSpeed);
        Audio_Manager.Instance.PlaySound(Audio_Manager.Sound.Shoot);
    }
}

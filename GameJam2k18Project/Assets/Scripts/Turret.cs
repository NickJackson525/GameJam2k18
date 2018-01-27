using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    #region Serialize Fields
    [SerializeField]
    [Tooltip("How quickly the turret fires in seconds")]
    private float fireRate = 0.5f; // how quickly the turret fires in seconds
    [SerializeField]
    [Tooltip("Idle turret sprite")]
    private Sprite idleSprite; // turret idle sprite (not firing)
    [SerializeField]
    [Tooltip("Firing turret sprite")]
    private Sprite firingSprite; // turret firing sprite
    [SerializeField]
    [Tooltip("The projectile to fire")]
    private GameObject projectilePrefab; // projectile to fire (prefab)
    [SerializeField]
    [Tooltip("The projectile speed")]
    private float projectileSpeed; // projectile speed
    [SerializeField]
    [Tooltip("Where the projectile spawns from")]
    private Transform projectileSpawn; // where the projectile spawns from
    #endregion

    #region Private Variables
    private SpriteRenderer sprite; // turret sprite
    private Vector2 fireDirection; // projectile direction
    #endregion

    #region Methods - MonoBehaviour
    private void Start()
    {
        sprite = this.gameObject.GetComponent<SpriteRenderer>();
        StartCoroutine(Fire());
    }
    #endregion

    #region Coroutines
    IEnumerator Fire()
    {
        while(true)
        {
            GameObject projectile = Instantiate(projectilePrefab);
            projectile.transform.position = projectileSpawn.position;
            // TODO: set projectile direction to match turret rotation
            projectile.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1, 0) * projectileSpeed);
            sprite.sprite = firingSprite;
            yield return new WaitForSeconds(0.025f);
            sprite.sprite = idleSprite;
            yield return new WaitForSeconds(fireRate);
        }
    }
    #endregion
}
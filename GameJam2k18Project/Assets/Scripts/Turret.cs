﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : Robot
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
    [Tooltip("Idle shield-turret sprite")]
    private Sprite shieldIdleSprite; // shield-turret idle sprite (not firing)
    [SerializeField]
    [Tooltip("Firing shield-turret sprite")]
    private Sprite shieldFiringSprite; // shield-turret firing sprite
    [SerializeField]
    [Tooltip("The projectile to fire")]
    private GameObject projectilePrefab; // projectile to fire (prefab)
    [SerializeField]
    [Tooltip("The projectile speed")]
    private float projectileSpeed; // projectile speed
    [SerializeField]
    [Tooltip("Where the projectile spawns from")]
    private Transform projectileSpawn; // where the projectile spawns from
    [SerializeField]
    [Tooltip("Minimum rotation value for gun")]
    private float minRotation = 0f; // minimum rotation value for gun
    [SerializeField]
    [Tooltip("Maximum rotation value for gun")]
    private float maxRotation = 180f; // maximum rotation value for gun
    [SerializeField]
    [Tooltip("Speed of gun rotation")]
    private float rotationSpeed = 3f; // how quickly the gun rotates
    #endregion

    #region Private Variables
    private SpriteRenderer sprite; // turret sprite
    private Vector2 fireDirection; // projectile direction
    private bool canFire; // whether or not the turret can fire
    private float fireDelay; // how long the turret must wait before firing
    private float rotZ = 0; // z rotation
    private int rotLeft = 0;
    private int rotRight = 0;
    private IEnumerator coroutine;
    private bool fireRoutineRunning = false;
    private bool initialPossess = false;
    #endregion

    #region Methods - MonoBehaviour
    protected override void Start()
    {
        sprite = this.gameObject.GetComponent<SpriteRenderer>();
        if(!isSelected)
        {
            coroutine = FireRoutine();
        }
    }

    protected override void Update()
    {
        if(isSelected)
        {
            base.Update();

            if(!initialPossess)
            {
                initialPossess = true;
                sprite.sprite = shieldIdleSprite;
                health = 100f;
                PlayRandomSound();
            }
            StopCoroutine(coroutine);
            fireRoutineRunning = false;
            if(Input.GetKey(KeyCode.A))
            {
                rotLeft = 1;
            }
            else
            {
                rotLeft = 0;
            }
            if(Input.GetKey(KeyCode.D))
            {
                rotRight = 1;
            }
            else
            {
                rotRight = 0;
            }
            rotZ += (rotRight - rotLeft) * rotationSpeed * Time.deltaTime;
            rotZ = Mathf.Clamp(rotZ, minRotation, maxRotation);
            this.gameObject.transform.localEulerAngles = new Vector3(
                this.gameObject.transform.localEulerAngles.x,
                this.gameObject.transform.localEulerAngles.y,
                rotZ);

            // firing logic
            if(Input.GetKey(KeyCode.Space)) // TODO: fire currently set to spacebar, possibly change control later
            {
                if(canFire)
                {
                    canFire = false;
                    Fire();
                    fireDelay = fireRate;
                }
            }

            fireDelay -= Time.deltaTime;

            if(fireDelay <= 0)
            {
                fireDelay = 0;
                canFire = true;
            }
        }
        else
        {
            initialPossess = false;
            TrackPlayer();
        }
    }
    #endregion

    #region Methods - Private
    private void TrackPlayer()
    {
        if(GameObject.FindGameObjectWithTag("Player"))
        {
            GameObject target = GameObject.FindGameObjectWithTag("Player");
            if (Vector3.Distance(this.gameObject.transform.position, target.transform.position) <= aggroDistance)
            {
                if (!fireRoutineRunning)
                {
                    fireRoutineRunning = true;
                    StartCoroutine(coroutine);
                }
                Vector3 trackDirection = this.gameObject.transform.position - target.transform.position;
                rotZ = Mathf.Atan2(trackDirection.y, trackDirection.x) * rotationSpeed;
                rotZ = Mathf.Clamp(rotZ, minRotation, maxRotation);
                this.gameObject.transform.localEulerAngles = new Vector3(
                    this.gameObject.transform.localEulerAngles.x,
                    this.gameObject.transform.localEulerAngles.y,
                    rotZ);
            }
            else
            {
                StopCoroutine(coroutine);
                fireRoutineRunning = false;
            }
        }
        else
        {
            StopCoroutine(coroutine);
        }
    }

    private void Fire()
    {
        GameObject projectile = Instantiate(projectilePrefab);
        projectile.transform.position = projectileSpawn.position;
        projectile.transform.rotation = this.gameObject.transform.rotation;
        Vector3 velocityDir = -(projectile.transform.right).normalized;
        projectile.GetComponent<Rigidbody2D>().AddForce(new Vector2(velocityDir.x, velocityDir.y) * projectileSpeed);
        Audio_Manager.Instance.PlaySound(0.2f, Audio_Manager.Sound.Shoot);
        if (isSelected)
        {
            sprite.sprite = shieldFiringSprite;
        }
        else
        {
            sprite.sprite = firingSprite;
        }
        StartCoroutine(SpriteSwitchRoutine());
    }

    private void PlayRandomSound()
    {
        switch (Random.Range(1, 10))
        {
            case 1:
                Audio_Manager.Instance.PlaySound(Audio_Manager.Sound.Turret1);
                break;
            case 2:
                Audio_Manager.Instance.PlaySound(Audio_Manager.Sound.Turret2);
                break;
            case 3:
                Audio_Manager.Instance.PlaySound(Audio_Manager.Sound.Turret3);
                break;
            case 4:
                Audio_Manager.Instance.PlaySound(Audio_Manager.Sound.Turret4);
                break;
            case 5:
                Audio_Manager.Instance.PlaySound(Audio_Manager.Sound.Turret5);
                break;
            case 6:
                Audio_Manager.Instance.PlaySound(Audio_Manager.Sound.Turret6);
                break;
            case 7:
                Audio_Manager.Instance.PlaySound(Audio_Manager.Sound.Turret7);
                break;
            case 8:
                Audio_Manager.Instance.PlaySound(Audio_Manager.Sound.Turret8);
                break;
            case 9:
                Audio_Manager.Instance.PlaySound(Audio_Manager.Sound.Turret9);
                break;
        }
    }
    #endregion

    #region Coroutines
    IEnumerator FireRoutine()
    {
        while(true)
        {
            Fire();
            yield return new WaitForSeconds(fireRate);
        }
    }

    IEnumerator SpriteSwitchRoutine()
    {
        yield return new WaitForSeconds(0.025f);
        if (isSelected)
        {
            sprite.sprite = shieldIdleSprite;
        }
        else
        {
            sprite.sprite = idleSprite;
        }
        yield break;
    }
    #endregion
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float damage = 3f;

    private void OnDisable()
    {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //print("Shot");
            collision.gameObject.GetComponent<Robot>().Health -= damage;
            if(collision.gameObject.GetComponent<Robot>().Health <= 0)
            {
                Destroy(collision.gameObject);
            }
        }
        Destroy(this.gameObject);
    }
}
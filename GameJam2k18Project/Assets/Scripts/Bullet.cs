using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Robot")
        {
            //print("Shot");
            collision.gameObject.GetComponent<Robot>().Health -= damage;
            //print(collision.gameObject.GetComponent<Robot>().Health);
            if(collision.gameObject.GetComponent<Robot>().Health <= 0)
            {
                Destroy(collision.gameObject);
                if (tag=="Player")
                {
                    SceneManager.LoadScene("LossScn");
                }
            }
        }
        Destroy(this.gameObject);
    }
}
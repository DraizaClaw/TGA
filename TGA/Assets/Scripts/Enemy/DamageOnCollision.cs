using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag==("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().Health = 0;
#pragma warning disable CS0618 // Type or member is obsolete
            DestroyObject(collision.gameObject);
#pragma warning restore CS0618 // Type or member is obsolete
            //the dots above are to supress a warning


            //something something unity particle system

        }
        else if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().currentHealth = 0;
        }
    }
}

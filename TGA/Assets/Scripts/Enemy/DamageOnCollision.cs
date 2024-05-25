using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollision : MonoBehaviour
{
    [SerializeField] private int Damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag==("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().CurrentHealth -= Damage;

        }
        else if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().currentHealth -= Damage;
        }
    }
}

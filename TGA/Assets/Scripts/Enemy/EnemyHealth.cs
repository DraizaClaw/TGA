using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] private int StartingHealth;
                     public int currentHealth;

    private void Start()
    {
        currentHealth = StartingHealth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Projectile>(out Projectile projectile))
            currentHealth -= projectile.Damage;
    }



}

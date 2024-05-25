using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int Health;
    public int CurrentHealth;

    [SerializeField] private Text HealthText;


    private void Start()
    {
        CurrentHealth = Health;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<EnemyProjectileLeft>(out EnemyProjectileLeft left))
            CurrentHealth -= left.Damage;

        if (collision.gameObject.TryGetComponent<EnemyProjectileRight>(out EnemyProjectileRight right))
            CurrentHealth -= right.Damage;
    }

    private void Update()
    {
        HealthText.text = "Health = " + CurrentHealth;
        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0; //for health text //asthetics /*not needed?*/

            Destroy(gameObject);

        }
    }
}

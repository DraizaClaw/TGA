using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int Health;
    private int CurrentHealth;

    [SerializeField] private GameObject DeathScreen;
    [SerializeField] private Text HealthText;


    private void Start()
    {
        DeathScreen.SetActive(false);
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
            print("Dead");
            Time.timeScale = 0;
            DeathScreen.SetActive(true);
            CurrentHealth = 0; //for health text //asthetics

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    /*
    [SerializeField] private GameObject BulletsContainer, Player, BulletPrefab;
    */
    [SerializeField] private float Speed, LifeTime;
    
    [SerializeField] private int Damage;

    [SerializeField] private Rigidbody2D rb;

    private GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        rb.velocity = new Vector2(Player.GetComponent<Transform>().localScale.x, 0f) * Speed;
        Invoke("DestroyProjectile", LifeTime);
    }
    
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}

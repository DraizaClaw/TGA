using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    /*
    [SerializeField] private GameObject BulletsContainer, Player, BulletPrefab;
    */
    [SerializeField] private float Speed, LifeTime;
    
    public int Damage;

    [SerializeField] private Rigidbody2D rb;

    private GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        rb.velocity = new Vector2(Player.GetComponent<Transform>().localScale.x, 0f) * Speed;
        Invoke("DestroyProjectile", LifeTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }



    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}

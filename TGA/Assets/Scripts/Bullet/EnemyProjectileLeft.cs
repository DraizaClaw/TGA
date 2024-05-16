using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileLeft : MonoBehaviour
{
    [SerializeField] private float Speed, LifeTime;

    public int Damage;

    [SerializeField] private Rigidbody2D rb;

    private GameObject Enemy;//not needed for now ig

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector2(-1f , 0f) * Speed;
        Invoke("DestroyProjectile", LifeTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, collision.gameObject.GetComponent<Rigidbody2D>().velocity.y);
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

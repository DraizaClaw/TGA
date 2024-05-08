using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileRight : MonoBehaviour
{
    [SerializeField] private float Speed, LifeTime;

    [SerializeField] private int Damage;

    [SerializeField] private Rigidbody2D rb;

    private GameObject Enemy;//not needed for now ig

    // Start is called before the first frame update
    void Start()
    {
        //change belwo va;ue of enemy
        //Enemy = this.GetComponentInParent;
        rb.velocity = new Vector2(1f , 0f) * Speed;


        Invoke("DestroyProjectile", LifeTime);
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}

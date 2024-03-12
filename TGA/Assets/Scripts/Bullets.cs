using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{

    [SerializeField] private GameObject BulletsContainer;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject BulletPrefab;
    [SerializeField] private float BulletSpeed;
    [SerializeField] private float BulletTime;
    [SerializeField] private float BulletTimeStart;


    private Rigidbody2D rb;

    private void Awake()
    {
        rb = BulletPrefab.GetComponent<Rigidbody2D>();
    }



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //fire bullets
            if (BulletsContainer.transform.childCount == 0)//if this bullets contyainer has no children
            {
                Instantiate(BulletPrefab, BulletsContainer.transform);
                BulletTimeStart = 0;
            }
            
        }
        while (BulletsContainer.transform.childCount == 0)
        {
            if (BulletTimeStart < BulletTime)
            {
                rb.velocity = new Vector2(Player.GetComponent<PlayerMovement>().LookingRight * BulletSpeed, 0);
                BulletTimeStart += 0.1f;
            }
            else
            {
                Object.Destroy(rb.gameObject);
                break;
            }
            
        }
    }
}

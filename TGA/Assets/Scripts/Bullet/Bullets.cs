using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{

    //Currently Useless





    /*

    [SerializeField] private GameObject BulletsContainer, Player, BulletPrefab, ChargedBulletPrefab;
    [SerializeField] private float BulletSpeed, BulletTime, ChargedBulletSpeed, ChargedBulletTime;
    [SerializeField] private int ChargeTime, Damage, ChargedDamage;

    private int lookingright, TimeCharging;


    private Rigidbody2D rb;

    


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && BulletsContainer.transform.childCount == 0)
        {
            if (Player.GetComponent<PlayerMovement>().LookingRight == true)
            {
                lookingright = 1;
            }
            else
            {
                lookingright = -1;
            }
            //this sets the value for looking right and left




            if (Input.GetKeyUp(KeyCode.E) && TimeCharging > ChargeTime)
            {
                //fire charged bullets
                Instantiate(ChargedBulletPrefab, BulletsContainer.transform);

                rb = BulletsContainer.GetComponentInChildren<Rigidbody2D>();

                Object.Destroy(BulletsContainer.transform.GetChild(0).gameObject, BulletTime);

                rb.velocity = new Vector2(lookingright * ChargedBulletSpeed, 0);
            }
            else if(Input.GetKeyUp(KeyCode.E) && TimeCharging < ChargeTime)
            {
                //fire bullets
                Instantiate(BulletPrefab, BulletsContainer.transform);

                rb = BulletsContainer.GetComponentInChildren<Rigidbody2D>();

                Object.Destroy(BulletsContainer.transform.GetChild(0).gameObject, BulletTime);

                rb.velocity = new Vector2(lookingright * BulletSpeed, 0);
            }


            
        }

        if (BulletsContainer.transform.childCount != 0)
        {
            rb.velocity = new Vector2(lookingright * BulletSpeed, 0);
        }


    }

    */
}

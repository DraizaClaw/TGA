using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{

    [SerializeField] private GameObject BulletsContainer, Player, BulletPrefab;
    [SerializeField] private float BulletSpeed, BulletTime;

    private int lookingright;


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


            //fire bullets
            Instantiate(BulletPrefab, BulletsContainer.transform);

            rb = BulletsContainer.GetComponentInChildren<Rigidbody2D>();

            Object.Destroy(BulletsContainer.transform.GetChild(0).gameObject, BulletTime);

            rb.velocity = new Vector2(lookingright * BulletSpeed, 0);
        }

        if (BulletsContainer.transform.childCount != 0)
        {
            rb.velocity = new Vector2(lookingright * BulletSpeed, 0);
        }


    }
}

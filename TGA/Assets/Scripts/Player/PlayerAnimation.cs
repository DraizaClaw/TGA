using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    private float chargetime;

    private void Update()
    {



        chargetime = GetComponentInChildren<Shooting>().ChargeTime;



        //if charge time >= 2       then color = red
        if (chargetime >= GetComponentInChildren<Shooting>().ChargeMin)
        {
            GetComponent<SpriteRenderer>().color = Color.red;//if charged shot is ready
        }
        else if (chargetime < 1) 
        {
            GetComponent<SpriteRenderer>().color = Color.yellow;//neutral
        }
        else if (chargetime < GetComponentInChildren<Shooting>().ChargeMin)
        {
            GetComponent<SpriteRenderer>().color = Color.cyan;//while charging
        }

    }
}

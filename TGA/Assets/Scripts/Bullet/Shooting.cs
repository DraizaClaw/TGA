using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    [SerializeField] private GameObject BulletPrefab;
    [SerializeField] private Transform Firepoint;

    [SerializeField] private GameObject ChargedBulletPrefab;
    [SerializeField] private float ChargeSpeed;
    
    public float ChargeTime;
    public float ChargeMin;
    private bool isCharging;
    


    private void Update()
    {

        if (Input.GetKey(KeyCode.E))
        {
            isCharging = true;
            if (isCharging==true)
            {
                ChargeTime += Time.deltaTime * ChargeSpeed;
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(BulletPrefab,Firepoint.position,Firepoint.rotation);
            ChargeTime = 0;
        }

        else if (Input.GetKeyUp(KeyCode.E) && ChargeTime < ChargeMin) 
        {
            isCharging = false;
            ChargeTime = 0;
        }

        else if(Input.GetKeyUp(KeyCode.E) && ChargeTime >= ChargeMin)
        {
            ReleaseCharge();
            isCharging = false;
            ChargeTime = 0;
        }
    }


    void ReleaseCharge() 
    {
        Instantiate(ChargedBulletPrefab, Firepoint.position, Firepoint.rotation);
        isCharging = false;
    }


}

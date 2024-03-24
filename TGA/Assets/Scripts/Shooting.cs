using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    [SerializeField] private GameObject BulletPrefab;
    [SerializeField] private Transform Firepoint;

    [SerializeField] private GameObject ChargedBulletPrefab;
    [SerializeField] private float ChargeSpeed,ChargeTime;
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
        else if(Input.GetKeyUp(KeyCode.E) && ChargeTime >= 2)
        {
            ReleaseCharge();
        }
    }


    void ReleaseCharge() 
    {
        Instantiate(ChargedBulletPrefab, Firepoint.position, Firepoint.rotation);
        isCharging = false;
        ChargeTime = 0;
    }


}

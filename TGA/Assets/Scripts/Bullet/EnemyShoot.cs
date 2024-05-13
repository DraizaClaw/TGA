using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    [SerializeField] private GameObject EnemyBulletLeft;
    [SerializeField] private GameObject EnemyBulletRight;
    [SerializeField] private GameObject EnemyParent;
    [SerializeField] private Transform Firepoint;
    [SerializeField] private LayerMask PlayerLayerMask;
    [SerializeField] private int Range;
    [SerializeField] private float CoolDownMin;
                     private float CoolDown;


    private void Update()
    {
        StartCoroutine( Shoot() );
        if (CoolDown > 0)
        {
            CoolDown -= 1 * Time.deltaTime;
        }
        
    }

    IEnumerator Shoot()
    {
        if (SeesPlayer() && CoolDown <= 0)
        {

            if (EnemyParent.GetComponent<Transform>().localScale.x > 0)//if posotive //if loooking right
                Instantiate(EnemyBulletRight, Firepoint.position, Firepoint.rotation, EnemyParent.transform);
            else
                Instantiate(EnemyBulletLeft, Firepoint.position, Firepoint.rotation, EnemyParent.transform); //if player to the right shoot right etc.
            CoolDown = CoolDownMin;
            yield return new WaitForSeconds(0.1f);
        }    
    }



    private bool SeesPlayer()
    {
        Debug.DrawRay(transform.position, Vector2.right * EnemyParent.transform.localScale.x);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * EnemyParent.transform.localScale.x, Range, PlayerLayerMask);
        //the number third argument is the distance of the raycast
        // Perform a raycast to check for fourth argument

        // Check if the raycast hits the EnemyParent
        return hit.collider != null;
    }
}

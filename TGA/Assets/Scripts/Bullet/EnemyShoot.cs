using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    [SerializeField] private GameObject EnemyBulletPrefab;
    [SerializeField] private GameObject bulletcase;//used as a case to hold bullet clones and guide them (left or right)
    [SerializeField] private GameObject EnemyParent;
    [SerializeField] private Transform Firepoint;
    [SerializeField] private LayerMask PlayerLayerMask;
    [SerializeField] private int Range;


    private void Update()
    {
        //draw raycast

        if (SeesPlayer())
        {
            Instantiate(EnemyBulletPrefab, Firepoint.position, Firepoint.rotation,EnemyParent.transform);
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

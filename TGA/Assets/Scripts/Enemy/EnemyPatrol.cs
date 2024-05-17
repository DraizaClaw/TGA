using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Patrol Points")]
    [SerializeField] private Transform RightEdge;
    [SerializeField] private Transform LeftEdge;

    [Header("Enemy")]
    [SerializeField] private Transform EnemyTransform;
    [SerializeField] private float Speed;
    private Vector3 initialScale;
    private bool MovingLeft;


    private void Awake()
    {
        initialScale = EnemyTransform.localScale;
    }

    private void Update()
    {
        if (GetComponentInChildren<EnemyHealth>().currentHealth <= 0)
        {
            Destroy(gameObject);
        }



        if (MovingLeft)
        {
            if (EnemyTransform.position.x >= LeftEdge.position.x)
                MoveInDirection(-1);
            else
                ChangeDirection();
        }
        else
        {
            if (EnemyTransform.position.x <= RightEdge.position.x)
                MoveInDirection(1);
            else
                ChangeDirection();
        }


        if (GetComponentInChildren<EnemyShoot>().SeesPlayer())
        {
            //stop moving //could keep it like this until we later decide enemy must stop moving
        }
    }






    private void ChangeDirection()
    {
        MovingLeft = !MovingLeft;
    }



    private void MoveInDirection(int direction)
    {   //Make enemy face direction
        EnemyTransform.localScale = new Vector3(Mathf.Abs(initialScale.x) * direction,
            initialScale.y, initialScale.z);

        //Move in that direction
        EnemyTransform.position = new Vector3(EnemyTransform.position.x + Time.deltaTime * direction * Speed,
            EnemyTransform.position.y, EnemyTransform.position.z);
    }

















}



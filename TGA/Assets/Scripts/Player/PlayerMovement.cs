using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//if error occours where bullet doesnt fire util player moves then check this script. in the update func



public class PlayerMovement : MonoBehaviour
{
    //this will make ther player jump and move


    private Rigidbody2D RigidBody;
    private BoxCollider2D boxcollider;

    private float horizontalInput;
    private bool onground;

    [SerializeField] private float speed;
    [SerializeField] private float jumpheight;

    public LayerMask GroundLayer;

    [HideInInspector] public int LookingRight;

    /*
    float right;
    private float left;
    *///unknown if this is needed. probably not

    private void Awake()
    {
        RigidBody = GetComponent<Rigidbody2D>();
        boxcollider = GetComponent<BoxCollider2D>();
    }






    //tweak these. player gains momentum but loses it the moment the else statement occurs
    private void Update()
    {



        horizontalInput = Input.GetAxis("Horizontal");

        RigidBody.velocity = new Vector2(horizontalInput * speed, RigidBody.velocity.y);
        if (horizontalInput > 0) //if player looking right
        {
            LookingRight = 1;

        }
        else if (horizontalInput < 0) //if player looking left
        {
            LookingRight = -1;
        }





        /*
        Mathf.Clamp(right, -0.5f, 0.5f);
        Mathf.Clamp(left, -0.5f, 0.5f);


        if (Input.GetKey((KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Right"))))
        {
            right += 0.05f;
            RigidBody.velocity = new Vector2(right * speed, RigidBody.velocity.y * Time.deltaTime) ;
        }
        else
        {
            right = 0;
        }

        if (Input.GetKey((KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Left"))))
        {
            left -= 0.05f;
            RigidBody.velocity = new Vector2(left * speed, RigidBody.velocity.y * Time.deltaTime);
        }
        else
        {
            left = 0;
        }

        */




        onground = IsTouchingGround();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (onground == true)
            {
                RigidBody.velocity = new Vector2(RigidBody.velocity.x, jumpheight);
            }


        }
    }

    private bool IsTouchingGround()
    {
        // Perform a raycast downwards to check for ground contact
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1, GroundLayer);

        // Check if the raycast hits the ground
        return hit.collider != null;
    }










}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//if error occours where bullet doesnt fire util player moves then check this script. in the update func



public class PlayerMovement : MonoBehaviour
{
    //this will make ther player jump and move

    private bool facingRight;
    private Rigidbody2D RigidBody;
    private BoxCollider2D boxcollider;

    private float horizontalInput;
    private bool onground;

    [SerializeField] private float speed;
    [SerializeField] private float jumpheight;

    public LayerMask GroundLayer;

    [HideInInspector] public bool LookingRight;

    /*
    float right;
    private float left;
    *///unknown if this is needed. probably not

    private void Awake()
    {
        RigidBody = GetComponent<Rigidbody2D>();
        boxcollider = GetComponent<BoxCollider2D>();
        facingRight = true;
    }






    //tweak these. player gains momentum but loses it the moment the else statement occurs
    private void Update(/*      Makes player move left/right and jump     */)
    {



        horizontalInput = Input.GetAxis("Horizontal");

        RigidBody.velocity = new Vector2(horizontalInput * speed, RigidBody.velocity.y);

        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)// if we are moving
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0f, 0f));
            if (Input.GetAxisRaw("Horizontal") > 0.5f && !facingRight)
            {
                //If we're moving right but not facing right, flip the sprite and set     facingRight to true.
                Flip();
                facingRight = true;
            }
            else if (Input.GetAxisRaw("Horizontal") < 0.5f && facingRight)
            {
                //If we're moving left but not facing left, flip the sprite and set facingRight to false.
                Flip();
                facingRight = false;
            }
        }

            /*
            if (Input.GetAxisRaw("Horizontal") > 0.5f) //if player looking right
            {
                transform.Rotate(0f, 0f, 0f);
                // LookingRight = true;

            }
            else if (Input.GetAxisRaw("Horizontal") < -0.5f) //if player looking left
            {
                transform.Rotate(0f, 180f, 0f);
                // LookingRight = false;
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
        //the number '1' is the distance the player has to be above the ground to jump
        // Check if the raycast hits the ground
        return hit.collider != null;
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }










}

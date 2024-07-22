using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//if error occours where bullet doesnt fire util player moves then check this script. in the update func



public class PlayerMovement : MonoBehaviour
{
    //this will make ther player jump and move

    private bool facingRight;
    private Rigidbody2D RigidBody;
    private CapsuleCollider2D boxcollider;//may not be needed

    private float horizontalInput;
    private bool onground;
    [Header("Movement")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpheight;

    public LayerMask GroundLayer;

    [HideInInspector] public bool LookingRight;

    [Header("Dash")]
    public bool CanDash = true;
    private bool isDashing;
    [SerializeField] private float DashPower;
    [SerializeField] private float DashTime;
    [SerializeField] private float DashCooldown;
    private TrailRenderer tr;//header dosen't work for some reason //nvm

    private void Start()
    {
        transform.position = new Vector3(PlayerPrefs.GetInt("Player Pos X"), PlayerPrefs.GetInt("Player Pos Y"), PlayerPrefs.GetInt("Player Pos Z"));
    }

    private void Awake()
    {
        RigidBody = GetComponent<Rigidbody2D>();
        boxcollider = GetComponent<CapsuleCollider2D>();
        tr = GetComponent<TrailRenderer>();
        facingRight = true;
    }



    private void Update(/*      Makes player move left/right and jump     */)
    {
        if (isDashing)
        {
            return;
        }

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

        
        onground = IsTouchingGround();  //maybe remove this variable
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (onground)
            {
                RigidBody.velocity = new Vector2(RigidBody.velocity.x, jumpheight);
            }
        }



        if (Input.GetKeyDown(KeyCode.Mouse0) && CanDash || Input.GetKeyDown(KeyCode.Q) && CanDash)
        {
            StartCoroutine(Dash());
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


    private IEnumerator Dash()
    {
        CanDash = false;
        isDashing = true;
        float OriginalGravity = RigidBody.gravityScale;
        RigidBody.gravityScale = 0f;
        RigidBody.velocity = new Vector2(transform.localScale.x * DashPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(DashTime);
        tr.emitting = false;
        RigidBody.gravityScale = OriginalGravity;
        isDashing = false;
        yield return new WaitForSeconds(DashCooldown);
        CanDash = true;

    }







}

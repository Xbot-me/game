using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //jumping player var
    bool grounded = false;
    float groundcheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float JumpHeight;
    //moving player var
    public float maxspeed;
    Rigidbody2D myRB; //var for getting the player
    Animator myAnim; //var for geting animation
    bool facingRight; // var for which direction player facing when game start

    //fire bullet var
    public Transform guntip;
    public GameObject bullet;
    float fireRate = 0.25f;
    float nextFire = 0f;




	// Use this for initialization
	void Start () {
        myRB = GetComponent <Rigidbody2D > (); //getting myRB
        myAnim = GetComponent<Animator>(); // getting animation 
        facingRight = true; //facing right

        
        
    }
    private void Update()
    {
        if (grounded && Input.GetAxis("Jump") > 0)
        {
            grounded = false;
            myAnim.SetBool("isGrounded", grounded);
            myRB.AddForce(new Vector2(0, JumpHeight));

            //firing bullet
           
        }
        if (Input.GetAxisRaw("Fire1") > 0)
        {
            fireRocket();
        }


    }

    // always use fixed update for physics component
   //fixed helps to create a platform free game 
    void FixedUpdate () {
        grounded = Physics2D.OverlapCircle(groundCheck.position,groundcheckRadius,groundLayer);
        myAnim.SetBool("isGrounded", grounded);
        myAnim.SetFloat("vertical speed", myRB.velocity.y);


        //MOVING AND ROTATING THE PLAYER BASED ON WHICH DIRECTION PLAYER MOVING


        float move = Input.GetAxis("Horizontal");  // getting A,D or Left or Right Arrow to move player
        myAnim.SetFloat("Speed", Mathf.Abs(move)); //setting animation speed
        myRB.velocity = new Vector2(move * maxspeed, myRB.velocity.y); //myRB is a rigid body so we can use vector2d to add velocity to my object and we only need x axis movement so we r making y same 

        if(move > 0 && !facingRight) //condition to check player moving and if its facing right or left
        {
            flip();// calling flip function to flip the player when needed
        }
        else if (move < 0 && facingRight)// we know input is -1 or 1 so we can decide which direction player moving depending on that
        {
            flip();// calling flip function to flip the player when needed
        }
    }
    //flip function to flip the player left or right depending on which key user presses 
    void flip()
    {
        facingRight = !facingRight;//we r making player face left or right depends on last direction
        Vector3 theScale = transform.localScale;//getting player local scale means we need player z axis
        theScale.x *= -1; // we need z axis cz if we multiply z axis with -1 player gonna rotate 180 degree
        transform.localScale = theScale; //now we r puting the input to the local scale

    }
    void fireRocket()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (facingRight)
            {
                Instantiate(bullet, guntip.position, Quaternion.Euler(new Vector3(0,0, 0)));
            }
            else if (!facingRight)
            {
                Instantiate(bullet, guntip.position, Quaternion.Euler(new Vector3(0,-2f, 180f)));
            }
        }
       

        
    }

}

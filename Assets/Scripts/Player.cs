using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxSpeed = 10f;
    public float jumpForce = 700f;
    bool facingRight = true;
    bool grounded = false;
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public int score;
    public float move;
    public float spawnX, spawnY;
    private bool isGrounded;
    public int extraJumps;
    private Rigidbody2D rb;



    // Start is called before the first frame update
    void Start()
    {
        spawnX = transform.position.x;
        spawnY = transform.position.y;
    }


    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        move = Input.GetAxis("Horizontal");
    }

    // Update is called once per frame
    void Update()
    {
        

        if (isGrounded == true)
        {
            extraJumps = 2;
        }



        if (grounded && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));
            if(Sound.sound != null) Sound.sound.PlaySound("positive");
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();

        extraJumps--;
        /*
      if (Input.GetKeyDown(KeyCode.UpArrow)&& extraJumps == 0 && isGrounded == true)
        {
           rb.velocity = Vector2.up * jumpForce;
           
        }*/


    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


   


    }



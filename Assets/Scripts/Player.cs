using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private Rigidbody2D rb;
    private float moveInput;

    private bool faceRight = true;

    public bool isGrounded;

  




    void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    void Start()
    {
        rb = GetComponent <Rigidbody2D> ();
    }

    
    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        rb.MovePosition(rb.position + Vector2.right * moveX * speed * Time.deltaTime);


        if (moveX > 0 && !faceRight)
            flip();

        else if (moveX < 0 && faceRight)
            flip();
    }
    void flip ()   
    {
        faceRight = !faceRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
          
        }

    }



  
}


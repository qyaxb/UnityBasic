using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] private playerWallBehavior wb;
    [SerializeField] private playerAnimation pa;
    [SerializeField] private playerHit ph;

    public float horizontal;
    public float speed = 8f;
    public float jumpingPower = 16f;
    public bool isFacingRight = true;
    public bool isJumping;
    public bool isFalling;
    public int jumpCounter;
    public bool isDoubleJump;


    void Start()
    {
        jumpCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //moving
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && jumpCounter < 1)
        {
            jumpCounter++;
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            isJumping = true;
            isFalling = false;
           
        }
        if(jumpCounter == 1)
        {
            isDoubleJump = true;
        }
        if(isGrounded())
        {
            jumpCounter = 0;
        }    
        if (Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            isFalling = true;
            isJumping = false;
            
        }
        wb.WallJump();
        wb.WallSlide();
        Flip();
        pa.playAnimator();

    }
    private void FixedUpdate()
    {
        if (!wb.isWallJumping)
        { if(ph.KBCounter <= 0)
            { 
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
            }
        }
    }

    public bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

    }


    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }


  

}
 

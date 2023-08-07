using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerWallBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isWallSliding;
    private float wallSlidingSpeed = 2f;

    public bool isWallJumping;
    private float wallJumpingDirection;
    private float wallJumpingTime = 0.2f;
    private float wallJumpingCounter;
    private float wallJumpingDuration = 0.4f;
    public Vector2 wallJumpingPower = new Vector2(8f, 16f);

    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask wallLayer;

    [SerializeField] private playerMovement pm;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool IsWalled()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
    }
    
    private void StopWallJumping()
    {
        isWallJumping = false;

    }


    public void WallJump()
    {
        if (isWallSliding && !isWallJumping)
        {

            isWallJumping = false;
            wallJumpingDirection = -pm.transform.localScale.x;
            wallJumpingCounter = wallJumpingTime;

            CancelInvoke(nameof(StopWallJumping));
        }
        else
        {
            wallJumpingCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump") && wallJumpingCounter > 0f && isWallSliding )
        {
            isWallJumping = true;
            pm.rb.velocity = new Vector2(wallJumpingDirection * wallJumpingPower.x, wallJumpingPower.y);
            wallJumpingCounter = 0f;
            pm.jumpCounter = 0;            

        }
        Invoke(nameof(StopWallJumping), wallJumpingDuration);
    }
    public void WallSlide()
    {
        if (IsWalled() && !pm.isGrounded() && pm.horizontal != 0)
        {
            isWallSliding = true;
            pm.rb.velocity = new Vector2(pm.rb.velocity.x, Mathf.Clamp(pm.rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
            pm.jumpCounter = 0;
           

        }
        else
        {

            isWallSliding = false;
           

        }
    }

}

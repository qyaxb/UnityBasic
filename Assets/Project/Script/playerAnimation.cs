using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimation : MonoBehaviour
{
    // Start is called before the first frame update
   [SerializeField] private playerMovement pm;
    [SerializeField] private Animator animator;
    [SerializeField] private playerWallBehavior wb;
   
    public void playAnimator()
    {   //N?u ?ang di chuy?n thì ch?y animation run   
        if (pm.horizontal != 0f)
        {
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
        //N?u ?ang nh?y thì s? ch?y animation Jump
        if(pm.isJumping && pm.jumpCounter == 0)
        {
            animator.SetBool("IsJumping", true);
        }    
        else
        {
            animator.SetBool("IsJumping", false);
        }
        //N?u ?ang r?i thì s? ch?y animation Fall
        float currentYVelocity = pm.rb.velocity.y;
        if (currentYVelocity < 0f)
        {
            animator.SetBool("IsFalling", true);
            pm.isJumping = false;
            pm.isDoubleJump = false;
            
        }
        else
        {
            animator.SetBool("IsFalling", false);
        }
        if (pm.isGrounded())
        {
            wb.isWallSliding = false;
            pm.isDoubleJump = false;
            animator.SetBool("IsFalling", false);
        }
        //N?u jumpCounter = 1 thì s? ch?y animation double jump
        if (pm.jumpCounter == 1)
        {
            animator.SetBool("IsDoubleJump", true);
        }    
        else
        {
            animator.SetBool("IsDoubleJump", false);
        }    
        //N?u ?ang ?u t??ng thì s? ch?y animation Wall Sliding
        if(wb.isWallSliding)
        {
            animator.SetBool("isWallSliding", true);
            animator.SetBool("IsFalling", false);
            animator.SetBool("IsDoubleJump", false);
        }
        else
        {
            animator.SetBool("isWallSliding", false);
        }
        //N?u ch?m ??t thì s? xóa tr?ng thái animation
    
       
    }

}


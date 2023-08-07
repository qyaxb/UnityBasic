using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHit : MonoBehaviour
{
    // Start is called before the first frame update
    public float KBForce = 5f;
    public float KBCounter;
    public float KBtotalTime;
    public bool knockFromRight;
    public float Iframe = 0f;
    public Animator animator;
    [SerializeField] private playerMovement pm;

    public void FixedUpdate()
    {
        if(KBCounter > 0 && Iframe <0)
        {
            if(knockFromRight)
            {
                pm.rb.velocity = new Vector2(-KBForce, KBForce);
            }
            if(!knockFromRight)
            {
                pm.rb.velocity = new Vector2(KBForce, KBForce);
            }
            animator.SetBool("IsDoubleJump", false);
            animator.SetTrigger("Hit");
            Iframe = 0.5f;
            pm.jumpCounter = 0;
        }
        KBCounter -= Time.deltaTime;
        Iframe -= Time.deltaTime;

    }

}

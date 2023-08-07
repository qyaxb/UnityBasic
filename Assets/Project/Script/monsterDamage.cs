using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterDamage : MonoBehaviour
{
    public int damage;
    public playerHealth playerHealth;
    public playerHit ph;
    public playerMovement pm;

    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            ph.KBCounter = ph.KBtotalTime;
            
            if(collision.transform.position.x <= transform.position.x)
            {
                ph.knockFromRight = true;
            }
            if (collision.transform.position.x > transform.position.x)
            {
                ph.knockFromRight = false;
            }
        
            playerHealth.takeDamage(damage);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireActivate : MonoBehaviour

{
    // Start is called before the first frame update
    public int damage;
    public playerHealth playerHealth;
    public playerHit ph;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ph.KBCounter = ph.KBtotalTime;

            if (collision.transform.position.x <= transform.position.x)
            {
                ph.knockFromRight = true;
            }
            if (collision.transform.position.x > transform.position.x)
            {
                ph.knockFromRight = false;
            }
;
            playerHealth.takeDamage(damage);
        }
    }
}

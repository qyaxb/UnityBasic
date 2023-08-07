using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int health = 10;
    // Start is called before the first frame update
    
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
   public void takeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}

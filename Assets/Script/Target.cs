using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    public float health = 50f;

    public void takeDamage(float amount)
    {
        //reduce the health variable by the amount of damage out of the shootscript
        health -= amount;
        
        //checks the health if it is 0 or lower to run function die
        if (health <= 0)
        {
            Die();
        }

        //if health gets to 0 or lower runs this
        void Die()
        {
            //currently just destroys the gameobject
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{

    public float damage = 10f;
    public float range = 100f;

    public Camera fpsCam;

    // Update is called once per frame
    void Update()
    {
        //excute the function shoot when left mousebutton 
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        //making the variable to save a small amount of data for the ray that has being shot
        RaycastHit hit;
        
        //if raycast var hit hits a collision makes it true and debug.log the name of the object
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            //testing what if the variable gets filled correctly 
            Debug.Log(hit.transform.name);

            //gets the value for target() script is in the object 
            Target target = hit.transform.GetComponent<Target>();
            
            //checks if the target doesnt come back as null
            if (target != null)
            {
                //puts the variable damage to the target script on the item you have hit
                target.takeDamage(damage);
            }
        }
    }
}

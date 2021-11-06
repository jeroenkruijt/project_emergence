using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiesDestroy : MonoBehaviour
{
    public float attackSpeed = 1f;
    private float coolDown = 0f;
    
    void Update()
    {
        coolDown -= Time.deltaTime;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Car"))
        {
            if(coolDown <= 0f)
            {
                other.GetComponent<props>().BreakProp(50);
                coolDown = 2f / attackSpeed;
            }
        }
    }
}


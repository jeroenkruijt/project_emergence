using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class props : MonoBehaviour
{
    [SerializeField]
    private int propsDamage = 100;
    private int currentDamage;
  
    void Start()
    {
        currentDamage = propsDamage;
    }

    public void BreakProp(int damageAmount)
    {
        currentDamage -= damageAmount;
        if (currentDamage <= 0)
        {
            //Debug.Log("destroyed");
            Destroy(gameObject);
        }
    }
    public int GetPropHP() {
        return currentDamage;
    }
}

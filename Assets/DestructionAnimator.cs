using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionAnimator : MonoBehaviour
{
    private props props;
    private MeshRenderer rend;
    public Material healthy;
    public Material damaged;
    public Material broken;
    private int maxHP;
    void Start()
    {
        props = GetComponent<props>();
        rend = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        //Get MAX HP from wall
        if (maxHP < props.GetPropHP()) {
            maxHP = props.GetPropHP();
        }
        if (props.GetPropHP() > maxHP * .75) {
            rend.material = healthy;
        } else if (props.GetPropHP() > maxHP * .5) {
            rend.material = damaged;
        } else if (props.GetPropHP() > maxHP * .25) {
            rend.material = broken;
        }



    }
}

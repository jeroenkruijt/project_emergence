using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : Interactable
{
    public Light m_Light;
    public bool pickedUp;
    private void Start() {
        PickUpUpgrade();
    }
    void PickUpUpgrade() {
        m_Light.enabled = pickedUp;
    }
    public override string GetDescription() {
        if (pickedUp) return "Press [E] to turn <color=red>off</color> the light.";
        return "Press [E] to turn <color=green>on</color> the light.";
    }

    public override void Interact() {
        pickedUp = !pickedUp;
        PickUpUpgrade();
    }
}

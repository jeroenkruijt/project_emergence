using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePickUp : Interactable
{
    public bool notPickedUp = true;
    public Upgrades upgrade;
    public UpgradeTracker tracker;
    private void Start() {
        tracker = GameObject.FindGameObjectWithTag("UpgradeTracker").GetComponent<UpgradeTracker>();
    }
    private void PickUpUpgrade() {

        // TODO: give weapon the power up
        tracker.UpgradeTest(upgrade);
        gameObject.SetActive(notPickedUp);
    }
    public override string GetDescription() {
        if (notPickedUp) return "<color=yellow>" + upgrade.upgradeText;
        return "";
    }
    /*
    public override string GetDescription() {
        if (notPickedUp) return "Press [E] to turn <color=red>off</color> the light.";
        return "Press [E] to turn <color=green>on</color> the light.";
    }*/

    public override void Interact() {
        notPickedUp = false;
        PickUpUpgrade();
    }
}

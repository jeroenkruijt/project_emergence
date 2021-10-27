using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrade", menuName = "Upgrade Pickup")]
public class Upgrades : ScriptableObject
{
    [System.Serializable]
    public class Upgrade {
        public float shootForce;
        public float upwardForce;
        public float timeBetweenShooting;
        public float spread;
        public float reloadTime;
        public float timeBetweenShots;
        public int magazineSize;
        public int bulletsPerTap;
    }
    [Header("Define the Upgrade")]
    public Upgrade upgradeInfo;
}

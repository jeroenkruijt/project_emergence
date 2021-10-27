using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrade", menuName = "Upgrade Pickup")]
public class Upgrades : ScriptableObject
{
    [System.Serializable]
    public class Upgrade {
        public string popupText;
        public float damage;
        public float bulletSpread;
        public float enemyKnockback;
        public int extraBullet;
    }
    [Header("Define the Upgrade")]
    public Upgrade upgradeInfo;
}

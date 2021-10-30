using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [System.Serializable]
    public class Upgrade {
        public Upgrades upgrade;
    }
    [Header("Insert Upgrade Info Below")]
    public Upgrade[] upgradeInfo;
}

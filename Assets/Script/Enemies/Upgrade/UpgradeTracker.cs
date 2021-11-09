using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeTracker : MonoBehaviour
{
    public Projectile_shooting weaponStats;
    public Upgrades upgrade;

    //Overall stats saved (in case its needed on scene switch)
    private int damage;
    private float shootForce;
    private float upwardForce;
    private float timeBetweenShooting;
    private float spread;
    private float reloadTime;
    private float timeBetweenShots;
    private int magazineSize;
    private int bulletsPerTap;
    private int bulletSplit;

    //adding these to save the picked up upgrade. this will be passed on to increase the gun values
    private int _damage;
    private float _shootForce;
    private float _upwardForce;
    private float _timeBetweenShooting;
    private float _spread;
    private float _reloadTime;
    private float _timeBetweenShots;
    private int _magazineSize;
    private int _bulletsPerTap;
    private int _bulletSplit;



    private void Start() {
        weaponStats = GameObject.FindGameObjectWithTag("Gun").GetComponent<Projectile_shooting>();
        //ImportWeaponStats();
    }

    public void UpgradeTest(Upgrades _upgrade) {
        Debug.Log("Upgrade complete!");
        Debug.Log(_upgrade.upgradeInfo.damage);


        damage += _upgrade.upgradeInfo.damage;
        shootForce += _upgrade.upgradeInfo.shootForce;
        upwardForce += _upgrade.upgradeInfo.upwardForce;
        timeBetweenShooting += _upgrade.upgradeInfo.timeBetweenShooting;
        spread += _upgrade.upgradeInfo.spread;
        reloadTime += _upgrade.upgradeInfo.reloadTime;
        timeBetweenShots += _upgrade.upgradeInfo.timeBetweenShots;
        magazineSize += _upgrade.upgradeInfo.magazineSize;
        bulletsPerTap += _upgrade.upgradeInfo.bulletsPerTap;

        _damage += _upgrade.upgradeInfo.damage;
        _shootForce += _upgrade.upgradeInfo.shootForce;
        _upwardForce += _upgrade.upgradeInfo.upwardForce;
        _timeBetweenShooting += _upgrade.upgradeInfo.timeBetweenShooting;
        _spread += _upgrade.upgradeInfo.spread;
        _reloadTime += _upgrade.upgradeInfo.reloadTime;
        _timeBetweenShots += _upgrade.upgradeInfo.timeBetweenShots;
        _magazineSize += _upgrade.upgradeInfo.magazineSize;
        _bulletsPerTap += _upgrade.upgradeInfo.bulletsPerTap;

        weaponStats.UpdateWeaponStats(_damage, _shootForce, _upwardForce, _timeBetweenShooting, _spread, _reloadTime, _timeBetweenShots, _magazineSize, _bulletsPerTap);
        ResetStats();
    }
    private void ResetStats() {
        _damage = 0;
        _shootForce = 0;
        _upwardForce = 0;
        _timeBetweenShooting = 0;
        _spread = 0;
        _reloadTime = 0;
        _timeBetweenShots = 0;
        _magazineSize = 0;
        _bulletsPerTap = 0;
        _bulletSplit = 0;
    }
    private void ImportWeaponStats() {
        damage = weaponStats.damage;
        shootForce = weaponStats.shootForce;
        upwardForce = weaponStats.upwardForce;
        timeBetweenShooting = weaponStats.timeBetweenShooting;
        spread = weaponStats.spread;
        reloadTime = weaponStats.reloadTime;
        timeBetweenShots = weaponStats.timeBetweenShots;
        magazineSize = weaponStats.magazineSize;
        bulletsPerTap = weaponStats.bulletsPerTap;
        //bulletsplit missing, as its in bullet object, and not in the rifle
    }
}

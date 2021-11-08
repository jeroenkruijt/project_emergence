using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject zombie;
    public GameObject[] spawnpoints;

    private float timer;
    private float timeElapsed = 0;
    private float spawnFreq = 5f;
    public float amountZombies;

    public void SpawnZombies(int amount) {

        var spawnpnt = Random.Range(0, 2);

        for (int i = 0; i < amount; i++) {
            if (amountZombies < 20) {
                Instantiate(zombie, spawnpoints[spawnpnt].transform.position, Quaternion.identity);
                amountZombies++;
            }
            
        }
        timeElapsed = Time.time;
        
    }
    private void Update() {
        if (Input.GetKeyDown(KeyCode.F)) {
            SpawnZombies(5);
        }

        timer = Time.time;

        if(Time.time - timeElapsed > spawnFreq) {
            SpawnZombies(AmountZombies());
        }
    }

    private int AmountZombies() {
        var amount = (timer * timer) * .0005f +1;
        return Mathf.RoundToInt(amount);
    }

}

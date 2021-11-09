using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{

    public enum SpawnState { SPAWNING, WAITING, COUNTING };

    [System.Serializable]
    public class Wave {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    private int nextWave = 0;

    public Transform[] spawnPoints;

    public float timeBetweenWaves = 5f;
    public float waveCountdown;
    
    public WaveDisplay ui;

    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.COUNTING;

    private void Start() {
        waveCountdown = timeBetweenWaves;

        ui = GameObject.FindGameObjectWithTag("WaveInfo").GetComponent<WaveDisplay>();

        if (spawnPoints.Length == 0) {
            Debug.Log("No Spawnpoints selected");
        }
    }

    private void Update() {

        if (state == SpawnState.WAITING) {
            //Check if enemies are still alive
            if (!EnemyIsAlive()) {
                // Begin a new round
                WaveCompleted();
                return;
            } else {
                return;
            }
            // Rewrite this to be a list of all enemies
        }

        if (waveCountdown <= 0) {
            if (state != SpawnState.SPAWNING) {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        } else {
            waveCountdown -= Time.deltaTime;
        }
    }

    void WaveCompleted() {
        ui.SetWaveText("Wave completed!");

        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1) {
            nextWave = 0;
            ui.SetWaveText("All waves completed! Looping...");
            // Unluck door here?
        } else {
            nextWave++;
        }

    }

    bool EnemyIsAlive() {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f) {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null) {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave(Wave _wave) {
        ui.SetWaveText("Get ready for: " + _wave.name);
        state = SpawnState.SPAWNING;

        for (int i = 0; i < _wave.count; i++) {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        state = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemy(Transform _enemy) {

        //Spawn enemy
        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy, _sp.transform.position, _sp.transform.rotation);
    }

}

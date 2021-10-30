using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public PlayerMovement player;
    public NavMeshAgent agent;
    public GameObject upgrade;

    //HP stuff
    private float hp = 100;

    private void Start() {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }
    void Update()
    {
        agent.SetDestination(player.transform.position);
        if (Input.GetKeyDown(KeyCode.H)) takeDamage(40);
    }

    public void takeDamage(float damage) {
        hp -= damage;
        checkIfDead();
    }
    private void checkIfDead() {
        if (hp <= 0) {
            Debug.Log("RIP I DIED");
            RollForUpgradeDrop();
            Destroy(gameObject);
        }
    }
    private void RollForUpgradeDrop() {
        if (Random.Range(0, 10) < 2) {
            SpawnUpgrade();
        }     
    }

    private void SpawnUpgrade() {
        Instantiate(upgrade, transform.position, Quaternion.identity);
    }
}

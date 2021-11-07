using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public PlayerMovement player;
    public NavMeshAgent agent;
    public GameObject upgrade;

    Animator anim;
    public float attackSpeed = 1f;
    private float attackCooldown = 0f;

    //HP stuff
    private float hp = 100;

    private void Start() {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        agent.SetDestination(player.transform.position);
        if (Input.GetKeyDown(KeyCode.H)) takeDamage(40);
        attackCooldown -= Time.deltaTime;
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

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            anim.SetTrigger("attack");
            if(attackCooldown <= 0f)
            {
                other.GetComponent<PlayerHealth>().TakeDamage(10);
                attackCooldown = 2f / attackSpeed;
            }
        }
    }
}

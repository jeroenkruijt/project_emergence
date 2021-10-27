using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public PlayerMovement player;
    public NavMeshAgent agent;

    private void Start() {
        agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        //Debug.Log()
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            //agent.destination = player.transform.position;
            //agent.SetDestination(player.transform.position);
            agent.SetDestination(player.transform.position);
            //RaycastHit hit;
            //Ray ray = Camera.main.ScreenPointToRay(player.transform.position);
            //if (Physics.Raycast(ray, out hit)) {
            //    agent.SetDestination(hit.point);
            //}
        }
    }
}

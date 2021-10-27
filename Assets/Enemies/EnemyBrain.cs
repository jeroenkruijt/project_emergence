using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBrain : MonoBehaviour
{
    public GameObject player;
    public Rigidbody rb;
    [SerializeField]
    private float spd = 30f;
    private Vector3 playerPos;
    private float playerX;
    private float playerZ;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = player.transform.position;
        playerX = player.transform.position.x;
        playerZ = player.transform.position.z;
    }
    private void FixedUpdate() {
        Move();
        //rb.AddForce(Mathf.Sign(playerX - transform.position.x) * spd * Time.deltaTime, 0f, Mathf.Sign(playerZ - transform.position.z) * spd * Time.deltaTime);
        //rb.velocity = new Vector3(Mathf.Sign(playerX - transform.position.x) * spd * Time.deltaTime, 0f, Mathf.Sign(playerZ - transform.position.z) * spd * Time.deltaTime);
    }

    private void Move() {
        float xDir = (playerX - transform.position.x);
        float zDir = (playerZ - transform.position.z);
        Vector3 dir = new Vector3(xDir, 0f, zDir);
        dir.Normalize();

        dir = dir * spd * Time.deltaTime;
        rb.velocity = dir;
    }

}

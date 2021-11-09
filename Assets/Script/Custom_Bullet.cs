using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Custom_Bullet : MonoBehaviour
{
    [Header("Please attatch components:")]
    public Rigidbody rb;
    public GameObject explosion;
    public LayerMask whatIsEnemies;

    [Header("Set the basic stats:")]
    [Range(0f,1f)]
    public float bounciness;
    public bool useGravity;

    [Header("Explosion dmg/rang/knockback:")]
    public int explosionDamage;
    public float explosionRange;
    public float explosionForce;

    [Header("Lifetime before expolding/dissapearing:")]
    public int maxCollisions;
    public float maxLifetime;
    public bool explodeOnTouch = true;
    
    [Header("Second bullets (Spawn after explosion)")]
    public GameObject secondBullet;
    public int sb_amount;
    public float sb_forwardForce, sb_upwardForce, sb_randomForce;

    int collisions;
    PhysicMaterial physics_mat;

   private void Start()
    {
        Setup();
    }

    private void Update()
    {
        //When to explode:
        if (collisions > maxCollisions) Explode();

        //Count down lifetime
        maxLifetime -= Time.deltaTime;
        if (maxLifetime <= 0) Explode();
    }

    private void Explode()
    {
        //Instantiate explosion
        if (explosion != null) Instantiate(explosion, transform.position, Quaternion.identity);

        //Check for enemies 
        Collider[] enemies = Physics.OverlapSphere(transform.position, explosionRange, whatIsEnemies);
        for (int i = 0; i < enemies.Length; i++)
        {
            //Get component of enemy and call Take Damage

            //Just an example!
            enemies[i].GetComponent<EnemyController>().takeDamage(explosionDamage);
            //Debug.Log(enemies[i]);

            //Add explosion force (if enemy has a rigidbody)
            if (enemies[i].GetComponent<Rigidbody>())
                enemies[i].GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, explosionRange);
        }

        //Add a little delay, just to make sure everything works fine
        //Invoke("Delay", 0.05f);
        Destroy(gameObject);
        
        //Spawn second bullets and add forces (if second bullet attatched
        if (secondBullet == null) return;

        for (int i = 0; i < sb_amount; i++)
        {
            float x = Random.Range(-1, 1f); float y = Random.Range(-1, 1f); float z = Random.Range(-1, 1f);
            Vector3 random = new Vector3(x, y, z);
            Rigidbody sb_rigidbody = Instantiate(secondBullet, transform.position + random, Quaternion.identity).GetComponent<Rigidbody>();

            //Add forces
            if (sb_forwardForce > 0)
                sb_rigidbody.AddForce(transform.forward * sb_forwardForce, ForceMode.Impulse);
            if (sb_upwardForce > 0)
                sb_rigidbody.AddForce(sb_rigidbody.transform.up * sb_upwardForce, ForceMode.Impulse);
            if (sb_randomForce > 0)
                sb_rigidbody.AddForce(random * sb_randomForce, ForceMode.Impulse);
            
            sb_amount--;
        }
    }
    private void Delay()
    {
        Destroy(gameObject);
    }

    public void SetDamage(int _damage) {
        explosionDamage = _damage;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Don't count collisions with other bullets
        if (collision.collider.CompareTag("Bullet")) return;

        //Count up collisions
        collisions++;

        //Explode if bullet hits an enemy directly and explodeOnTouch is activated
        if (collision.collider.CompareTag("Enemy") && explodeOnTouch) Explode();
    }

    private void Setup()
    {
        //Create a new Physic material
        physics_mat = new PhysicMaterial();
        physics_mat.bounciness = bounciness;
        physics_mat.frictionCombine = PhysicMaterialCombine.Minimum;
        physics_mat.bounceCombine = PhysicMaterialCombine.Maximum;
        //Assign material to collider
        GetComponent<SphereCollider>().material = physics_mat;

        //Set gravity
        rb.useGravity = useGravity;
    }

    /// Just to visualize the explosion range
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRange);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float fireRate = 2f; // Time between shots
    public int health = 3;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireForce = 20f;
    public float shootingRange = 10f;

    private GameObject player;
    private float nextFireTime = 0f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); // Assuming the player has the tag "Player"
    }

    void Update()
    {
        if (player != null)
        {
            MoveTowardsPlayer();

            float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
            if (distanceToPlayer <= shootingRange && Time.time >= nextFireTime)
            {
                ShootAtPlayer();
                nextFireTime = Time.time + 1f / fireRate;
            }
        }
    }

    void MoveTowardsPlayer()
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);

        // Rotate enemy to face the player
        Vector2 aimDirection = player.transform.position - transform.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0, 0, aimAngle);
    }

    void ShootAtPlayer()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }

   public void TakeDamage(int damage)
{
    health -= damage;
    Debug.Log("Enemy health: " + health); // Debug message to track health

    if (health <= 0)
    {
        Debug.Log("Enemy destroyed!");
        Destroy(gameObject);
    }
}

}

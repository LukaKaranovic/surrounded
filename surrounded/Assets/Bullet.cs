using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float timeToLiveBullets = 2f;
    public int damage = 1;

    void Start()
    {
        Destroy(gameObject, timeToLiveBullets);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object hit has the "Enemy" tag
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Bullet hit enemy!"); // Debug message to confirm collision

            // Try to get the Enemy component and apply damage
            EnemyController enemy = other.GetComponent<EnemyController>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage); // Apply damage to the enemy
                Debug.Log("Enemy took damage! Remaining health: " + enemy.health);
            }

            // Destroy the bullet after impact
            Destroy(gameObject);
        }
    }
}

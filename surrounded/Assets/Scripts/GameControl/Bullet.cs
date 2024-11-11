using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameControl
{
    public class Bullet : MonoBehaviour
    {
        public float timeToLiveBullets = 2f;
        public float damage;

        protected virtual void Start()
        {
            Destroy(gameObject, timeToLiveBullets);
        }

        public void setDamage(float dam)
        {
            damage = dam;
        }

        public virtual void OnTriggerEnter2D(Collider2D other)
        {
            // Check if the object hit has the "Enemy" tag
            if (other.CompareTag("Enemy"))
            {
                Debug.Log("Bullet hit enemy!"); // Debug message to confirm collision

                // Try to get the Enemy component and apply damage
                EnemyController enemy = other.GetComponent<EnemyController>();
                if (enemy != null)
                {
                    enemy.takeDamage(damage); // Apply damage to the enemy
                    Debug.Log("Enemy took damage! Remaining health: " + enemy.health);
                }

                // Destroy the bullet after impact
                Destroy(gameObject);
            }

            if (other.CompareTag("Asteroid"))
            {
                AsteroidController asteroid = other.GetComponent<AsteroidController>();
                if (asteroid != null)
                {
                    asteroid.takeDamage(1);
                }

                Destroy(gameObject);
            }

            if (other.CompareTag("Player"))
            {
                Debug.Log("Bullet hit player!");

                PlayerController player = other.GetComponent<PlayerController>();
                if (player != null)
                {
                    player.takeDamage(damage);
                    Debug.Log("Player took damage!");
                }

                //Destroy bullet after impact
                Destroy(gameObject);
            }
        }
    }
}
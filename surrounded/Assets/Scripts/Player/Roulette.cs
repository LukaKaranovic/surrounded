using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;

namespace Player
{
    public class Roulette : MonoBehaviour
    {
        public GameObject player;
        private PlayerController p;
        [SerializeField] private Transform m_centerObject;
        [SerializeField] float m_rotationSpeed = 10f;
        [SerializeField] private float m_orbitOffset;
        public bool isBall1 = false, isBall2 = false, isBall3 = false;

        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            p = player.gameObject.GetComponent<PlayerController>();
            m_centerObject = p.transform;
        }

        void Update()
        {
            if (player != null)
            {
                float angle = Time.time * m_rotationSpeed;
                if (isBall2)
                {
                    angle = (Time.time * m_rotationSpeed) + 2;
                }

                if (isBall3)
                {
                    angle = (Time.time * m_rotationSpeed) - 2;
                }

                var positionCenterObject = m_centerObject.position;

                var x = positionCenterObject.x + Mathf.Cos(angle) * m_orbitOffset;
                var y = positionCenterObject.y + Mathf.Sin(angle) * m_orbitOffset;
                transform.position = new Vector3(x, y);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            // Check if the object hit has the "Enemy" tag
            if (other.CompareTag("Enemy"))
            {
                Debug.Log("Roulette hit enemy!"); // Debug message to confirm collision

            // Try to get the Enemy component and apply damage
            EnemyController enemy = other.GetComponent<EnemyController>();
            if (enemy != null)
            {
                enemy.takeDamage((int)(p.stats.damage *2)); // Apply damage to the enemy
                Debug.Log("Enemy took damage! Remaining health: " + enemy.health);
            }

            }
        }
    }
}
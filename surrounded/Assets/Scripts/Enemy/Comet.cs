using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameControl;
using Player;

namespace Enemy {
    public class Comet : EnemyController
    {
        // Start is called before the first frame update
        void Start()
        {
            //yoinked from asteroid controller
            player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                moveTarget = FindPointNearPlayer();
                Vector3 heading = ((moveTarget + player.transform.position) - transform.position).normalized;
                rb = GetComponent<Rigidbody2D>();
                rb.AddForce(heading * maxSpeed, ForceMode2D.Impulse);
                rb.AddTorque(200);
                // asteroid towards player
            }
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (player != null)
            {
                MoveTowardsPlayer();
            }
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                PlayerController player = other.gameObject.GetComponent<PlayerController>();
                FindObjectOfType<AudioManager>().Play("Explosion", 0.1f);
                FindObjectOfType<AudioManager>().Play("Metal", 0.1f);
                player.KillPlayer();
            }
            if (other.gameObject.CompareTag("Enemy"))
            {
                // get enemy
                EnemyController enemy = other.gameObject.GetComponent<EnemyController>();
                enemy.destroyedByAsteroid = true;
                enemy.takeDamage(enemy.health);
            }
        }
    }
}

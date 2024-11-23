using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Player;

namespace Enemy.C0BU5
{
    public class CobusHand : MonoBehaviour
    {
        public Transform firePoint;
        public float ContactDamage;
        public float maxSpeed;

        private Rigidbody2D rb;
        private GameObject player;
        private Transform target;

        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player"); // Assuming the player has the tag "Player"
            rb = GetComponent<Rigidbody2D>();
        }

        void FixedUpdate()
        {
            if (player != null)
            {
                MoveToTarget();
                RotateToPlayer();
            }
        }

        protected void RotateToPlayer()
        {
            Vector2 aimDirection = player.transform.position - transform.position;
            float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg + 90;
            rb.rotation = aimAngle;
        }

        public void SetMoveTarget(Transform moveTarget)
        {
            target = moveTarget;
        }

        private void MoveToTarget()
        {
            if (Vector3.Distance(transform.position, target.position) < 0.2)
            {
                return;
            }

            Vector3 heading = ((target.position) - transform.position).normalized;
            if (rb.velocity.magnitude > maxSpeed)
            {
                rb.AddForce(maxSpeed * -rb.velocity.normalized, ForceMode2D.Impulse);
            }

            rb.AddForce(maxSpeed / 2 * heading, ForceMode2D.Impulse);
        }


        public void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                // get enemy
                PlayerController player = other.gameObject.GetComponent<PlayerController>();

                // damage both heavily
                player.takeDamage(ContactDamage);
            }
        }
    }
}

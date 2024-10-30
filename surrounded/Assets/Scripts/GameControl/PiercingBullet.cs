using UnityEngine;

namespace GameControl
{
    public class PiercingBullet : Bullet
    {
        public int pierce_capacity;
        private int pierced;

        /**
         * Overriden from Bullet::Start
         * Provides the same functionality, but also sets the pierce count to 0.
         */
        protected override void Start()
        {
            pierced = 0;
            Destroy(gameObject, timeToLiveBullets);
        }

        /**
         * Programmatically set the pierce capacity
         * @param pc Pierce capacity
         */
        public void setPierceCapacity(int pc)
        {
            pierce_capacity = pc;
        }

        /**
         * Overriden from Bullet::OnTriggerEnter2D
         * Has same functionality, but prevents bullet from being destroyed if it has pierces left.
         * @param other the other Collider interacted with
         */
        public override void OnTriggerEnter2D(Collider2D other)
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

                // Destroy the bullet after impact *if* it is out of pierces
                pierced++;
                if (pierced >= pierce_capacity)
                {
                    Destroy(gameObject);
                }
            }
            if (other.CompareTag("Asteroid")){
                AsteroidController asteroid = other.GetComponent<AsteroidController>();
                if(asteroid != null){
                    asteroid.takeDamage(1);
                }

                // destroy bullet if it is out of pierces
                pierced++;
                if (pierced >= pierce_capacity)
                {
                    Destroy(gameObject);
                }
            }
            if (other.CompareTag("Player")) {
                Debug.Log("Bullet hit player!");
            
                PlayerController player = other.GetComponent<PlayerController>();
                if (player != null) {
                    player.takeDamage(damage);
                    Debug.Log("Player took damage!");
                }

                //Destroy bullet after impact if no pierces left
                pierced++;
                if (pierced >= pierce_capacity) 
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
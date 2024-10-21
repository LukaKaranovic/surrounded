using UnityEngine;

public class AsteroidController : EnemyController
{

    private Vector3 moveTarget;
    
    void Start()
    {
        /*  It was a good thought. Doesn;t work though.
        Vector2 direction = Random.insideUnitCircle; // should be Vector2 for 2D, yeah?
        transform.Rotate(direction);
        GetComponent<Rigidbody2D>().AddForce(transform.forward, ForceMode2D.Impulse);
        */
        player = GameObject.FindGameObjectWithTag("Player");
        moveTarget = FindPointNearPlayer();
        Vector3 heading = ((moveTarget + player.transform.position) - transform.position).normalized;
        GetComponent<Rigidbody2D>().AddForce(heading, ForceMode2D.Impulse);
        // asteroid towards player
    }
    
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            // do nothing, redundant. handled by Bullet
            return;
        }

        if (other.gameObject.CompareTag("Player"))
        {
            // get enemy
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            
            Debug.Log("Asteroid hit player! Inflicting damage!");
            // damage both heavily
            player.takeDamage(50);
            this.takeDamage(50); // stretch goal -- received damage configurable by upgrades
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            // get enemy
            EnemyController enemy = other.gameObject.GetComponent<EnemyController>();
            Debug.Log("Asteroid hit other enemy! Inflicting heavy damage!");
            enemy.takeDamage(100);
            this.takeDamage(100);
        }
    }

    void Update()
    {
        // this section intentionally left blank
    }
}
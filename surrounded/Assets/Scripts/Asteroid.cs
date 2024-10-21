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

    void Update()
    {
        // this section intentionally left blank
    }
}
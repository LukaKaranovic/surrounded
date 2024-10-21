using UnityEngine;

public class AsteroidController : EnemyController
{
    
    void Start()
    {
        Vector2 direction = Random.insideUnitCircle; // should be Vector2 for 2D, yeah?
        transform.Rotate(direction);
        GetComponent<Rigidbody2D>().AddForce(transform.forward, ForceMode2D.Impulse);
    }

    void Update()
    {
        // this section intentionally left blank
    }
}
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CobusHand : MonoBehaviour
{
    public Transform firePoint;
    public float ContactDamage;
    public float maxSpeed;

    private Rigidbody2D rb;
    private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); // Assuming the player has the tag "Player"
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {   
        if (player != null)
        {
            MoveTowardsPlayer();
            RotateToPlayer();
        }
    }
    protected void RotateToPlayer()
    {
        Vector2 aimDirection = player.transform.position - transform.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg + 90;
        rb.rotation = aimAngle;
    }
    protected void MoveTowardsPlayer() //moves enemy towards player in a straight line
    {
        Vector3 heading = ((player.transform.position) - transform.position).normalized;
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.AddForce(maxSpeed * -rb.velocity.normalized, ForceMode2D.Impulse);
        }
        rb.AddForce(maxSpeed * heading, ForceMode2D.Impulse);
    }

    private void moveToPosition(Vector3 position)
    {
        Vector3 heading = ((position) - transform.position).normalized;
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.AddForce(maxSpeed * -rb.velocity.normalized, ForceMode2D.Impulse);
        }
        rb.AddForce(maxSpeed * heading, ForceMode2D.Impulse);
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

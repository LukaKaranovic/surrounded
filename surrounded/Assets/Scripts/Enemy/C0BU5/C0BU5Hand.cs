using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CobusHand : EnemyController
{
    protected new void RotateTowardsPlayer()
    {
        Vector2 aimDirection = player.transform.position - transform.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg + 90;
        transform.rotation = Quaternion.Euler(0, 0, aimAngle);
    }
        void FixedUpdate()
    {   
        if (player != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);  
            MoveNearPlayer();
            RotateTowardsPlayer();
            if (distanceToPlayer <= shootingRange && Time.time >= nextFireTime)
            {
                ShootAtPlayer(damage);
                nextFireTime = Time.time + 1f / fireRate;
            }
        }
    }
    protected new void MoveNearPlayer()
    {
        if (Vector2.Distance(transform.position, player.transform.position + moveTarget) < 1)  //Enemy is near target position
        {
            moveTarget = FindPointNearPlayer();
        } 
        Vector3 heading = ((moveTarget + player.transform.position) - transform.position).normalized;   
        heading = avoidanceAdjustment(heading); 
       // transform.position += maxSpeed * Time.deltaTime * heading;
        if(rb.velocity.magnitude > maxSpeed)
        {
            rb.AddForce(maxSpeed * -rb.velocity.normalized, ForceMode2D.Force);
        }
        Debug.DrawLine(transform.position, player.transform.position + moveTarget);
        Debug.DrawLine(transform.position, transform.position + heading, Color.red);
        rb.AddForce(maxSpeed * heading,ForceMode2D.Force);
    }
    public new void OnCollisionEnter2D(Collision2D other)
    {
    }
}

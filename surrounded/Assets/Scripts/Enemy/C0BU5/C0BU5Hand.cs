using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CobusHand : EnemyController
{
    protected void RotateToPlayer()
    {
        Vector2 aimDirection = player.transform.position - transform.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg + 90;
        rb.rotation = aimAngle;
    }
        void FixedUpdate()
    {   
        if (player != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);  
            MoveTowardsPlayer();
            RotateToPlayer();
            if (distanceToPlayer <= shootingRange && Time.time >= nextFireTime)
            {
                ShootAtPlayer(damage);
                nextFireTime = Time.time + 1f / fireRate;
            }
        }
    }

    public new void OnCollisionEnter2D(Collision2D other)
    {
    }
}

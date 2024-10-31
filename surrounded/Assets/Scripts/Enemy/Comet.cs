using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comet : EnemyController
{   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
  void FixedUpdate()
    {   
        if (player != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);  
            MoveNearPlayer();
            RotateTowardsPlayer();
        }
    }
}

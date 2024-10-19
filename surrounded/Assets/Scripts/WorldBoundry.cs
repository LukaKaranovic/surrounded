using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldBoundary : MonoBehaviour
{
   public GameOverScreen gameOverScreen;
   public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerController target = other.gameObject.GetComponent<PlayerController>();
            target.takeDamage(target.health);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyController enemy = other.gameObject.GetComponent<EnemyController>();
            enemy.takeDamage(enemy.health);
        }
    }
}
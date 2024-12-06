using Enemy;
using GameControl;
using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactorialBullet : MonoBehaviour
{
    public int SplitAmount = 1;
    public int FactorialCap = 4;
    private float splitTime = 0.5f;
    public float damage;

    public GameObject FactorialPrefab;

    void Start()
    {
        StartCoroutine(BulletLife());
    }

    private IEnumerator BulletLife()
    {
        yield return new WaitForSeconds(splitTime);
        if (SplitAmount < FactorialCap)
        {
            for (int i = 0; i < SplitAmount; i++)
            {
                Quaternion offsetRotation = Quaternion.Euler(0, 0, Mathf.Pow(-1,i)*(20*i));
                GameObject bullet = Instantiate(FactorialPrefab, this.transform.position, this.transform.rotation * offsetRotation);
                bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.up * 5, ForceMode2D.Impulse);
                bullet.GetComponent<FactorialBullet>().SplitAmount = this.SplitAmount + 1;
            }
            Destroy(gameObject);
        }   else
        {
            Destroy(gameObject,4);
        }
    }

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Bullet hit player!");

            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.takeDamage(damage);
                Debug.Log("Player took damage!");
            }

            //Destroy bullet after impact
            Destroy(gameObject);
        }
    }
}

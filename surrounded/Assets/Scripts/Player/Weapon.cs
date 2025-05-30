using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameControl;

namespace Player
{
    public class Weapon : MonoBehaviour
    {
        public GameObject bulletPrefab;
        public Transform firePoint, firePoint2, firePoint3;
        public float fireForce = 50f;
        public float fireRate = 5.0f;
        public float baseRate = 5.0f;
        private float nextFireTime = 0f;

        public void Fire(float damage)
        {
            if (Time.time >= nextFireTime)
            {
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
                bullet.GetComponent<Bullet>().setDamage(damage);
                nextFireTime = Time.time + 1f / fireRate;
                FindObjectOfType<AudioManager>().Play("Weapon Fire", 0.5f);
            }
        }

        public void Diverge(float numOf, float damage)
        {
            float debuff = (numOf * 0.05f) + 0.5f;
            if (debuff >= 1)
            {
                debuff = 1;
            }

            if (Time.time >= nextFireTime)
            {
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                GameObject bullet2 = Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);
                GameObject bullet3 = Instantiate(bulletPrefab, firePoint3.position, firePoint3.rotation);

                bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * (fireForce), ForceMode2D.Impulse);
                bullet2.GetComponent<Rigidbody2D>().AddForce(firePoint2.up * (fireForce), ForceMode2D.Impulse);
                bullet3.GetComponent<Rigidbody2D>().AddForce(firePoint3.up * (fireForce), ForceMode2D.Impulse);
                bullet.GetComponent<Bullet>().setDamage(damage);
                bullet2.GetComponent<Bullet>().setDamage(damage);
                bullet3.GetComponent<Bullet>().setDamage(damage);
                nextFireTime = Time.time + 1f / (debuff * fireRate);
                FindObjectOfType<AudioManager>().Play("Weapon Fire", 0.2f);
            }
        }
        //shootingAudio.PlayOneShot(shootingClip);
    }
}
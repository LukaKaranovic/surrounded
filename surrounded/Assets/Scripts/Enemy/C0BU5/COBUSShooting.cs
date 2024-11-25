using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COBUSShooting : MonoBehaviour
{

    private GameObject player;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    public GameObject bulletFab;
    public Transform bulletPos;
    public float force = 5;
    private float nextFireTime = 0f;
    private float timer;
    public float fireRate = 5.0f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
    }

    // Update is called once per frame
    void Update(){
        Fire();
    }

    public void Fire(){
        if (Time.time >= nextFireTime)
        {
            GameObject bullet = Instantiate(bulletFab, bulletPos.position, bulletPos.rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(bulletPos.up * force, ForceMode2D.Impulse);
            nextFireTime = Time.time+ 1f/fireRate;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COBUSShooting : MonoBehaviour
{

    private GameObject player;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    public GameObject bullet;
    public Transform bulletPos;
    public float force = 5;

    private float timer;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        {
            timer = 0;
            shoot();
        }
    }

    void shoot() {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}

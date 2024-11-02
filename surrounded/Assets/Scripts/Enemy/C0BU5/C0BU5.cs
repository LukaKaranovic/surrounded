using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.CinemachineOrbitalTransposer;

public class C0BU5 : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    private Vector3 hoverOffset;
    private float maxSpeed;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        maxSpeed = player.GetComponent<PlayerController>().moveSpeed/2;
    }

    void HoverPlayer()
    {
        Vector3 target = new(player.transform.position.x, transform.position.y, 0f);
        float speed = maxSpeed;
        speed -= maxSpeed / (Mathf.Abs(transform.position.x - target.x) + 1);
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    void FixedUpdate()
    {
        HoverPlayer();
    }
}

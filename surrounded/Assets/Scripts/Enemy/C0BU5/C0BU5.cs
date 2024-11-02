using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.CinemachineOrbitalTransposer;

public class C0BU5 : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    private Vector3 hoverOffset;
    private float moveSpeed;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        moveSpeed = player.GetComponent<PlayerController>().moveSpeed/2;
    }

    void HoverPlayer()
    {
        Vector3 target = new(player.transform.position.x, transform.position.y, 0f);
        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
    }

    void FixedUpdate()
    {
        HoverPlayer();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.CinemachineOrbitalTransposer;

public class C0BU5 : MonoBehaviour
{
    public Transform neutralRight;
    public Transform neutralLeft;
    public Transform raisedRight;
    public Transform raisedLeft;

    public GameObject right;
    public GameObject left;

    private CobusHand leftHand;
    private CobusHand rightHand;

    private GameObject player;
    private Rigidbody2D rb;
    private Vector3 hoverOffset;
    private float maxSpeed;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        maxSpeed = player.GetComponent<PlayerController>().moveSpeed/2;
        rightHand = right.GetComponent<CobusHand>();
        leftHand = left.GetComponent<CobusHand>();
        SetHandsNeutral();
        StartCoroutine(Phase1());
    }
    void FixedUpdate()
    {
        HoverPlayer();
    }

    void SetHandsRaised()
    {
        leftHand.SetMoveTarget(raisedLeft);
        rightHand.SetMoveTarget(raisedRight);
    }

    void SetHandsNeutral()
    {
        leftHand.SetMoveTarget(neutralLeft);
        rightHand.SetMoveTarget(neutralRight);
    }

    void HoverPlayer()
    {
        Vector3 target = new(player.transform.position.x, transform.position.y, 0f);
        float speed = maxSpeed;
        speed -= maxSpeed / (Mathf.Abs(transform.position.x - target.x) + 1);
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    IEnumerator Phase1()
    {
        //placehholder for now -- flaps hands from neutral to raised
        while (true)
        {
            SetHandsNeutral();
            Debug.Log("hands Neutral");
            yield return new WaitForSeconds(3);
            SetHandsRaised();
            Debug.Log("hands Raised");
            yield return new WaitForSeconds(3);
        }
    }
}

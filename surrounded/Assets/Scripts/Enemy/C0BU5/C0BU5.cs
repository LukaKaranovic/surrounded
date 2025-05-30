using System.Collections;
using UnityEngine;
using static Cinemachine.CinemachineOrbitalTransposer;
using Player;
using GameControl;

namespace Enemy.C0BU5
{
    public class C0BU5 : MonoBehaviour
    {
        public Transform neutralRight;
        public Transform neutralLeft;
        public Transform raisedRight;
        public Transform raisedLeft;
        private SpriteRenderer sprite;

        public GameObject right;
        public GameObject left;

        private CobusHand leftHand;
        private CobusHand rightHand;

        private GameObject player;
        private Rigidbody2D rb;
        private Vector3 hoverOffset;
        private float maxSpeed;
        private float health = 5000;

        public void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            maxSpeed = player.GetComponent<PlayerController>().stats.moveSpeed / 2;
            rightHand = right.GetComponent<CobusHand>();
            leftHand = left.GetComponent<CobusHand>();
            sprite = GetComponent<SpriteRenderer>();
            rightHand.cobus = this;
            leftHand.cobus = this;
            SetHandsNeutral();
            StartCoroutine(Phase1());
        }

        public void FixedUpdate()
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

        public void takeDamage(float damage)
        {
            health -= damage;
            Debug.Log("Enemy health: " + health); // debug message to track health
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

        public void OnTriggerEnter2D(Collider2D other){
            if(other.CompareTag("Bullet")){
                takeDamage(other.GetComponent<Bullet>().damage);
                StartCoroutine(FlashRed());
                Destroy(other.gameObject);
            }
        }

        IEnumerator FlashRed()
        {
            sprite.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            sprite.color = Color.white;
        }

    }
}
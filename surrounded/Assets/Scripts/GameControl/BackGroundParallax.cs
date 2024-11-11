using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace GameControl
{
    public class BackGroundParallax : MonoBehaviour
    {
        private Vector2 size, startpos;
        public GameObject cam;

        public float parallaxEffect;

        // Start is called before the first frame update
        void Start()
        {
            startpos = transform.position;
            size = GetComponent<SpriteRenderer>().bounds.max;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            Vector2 distance = cam.transform.position * parallaxEffect;
            transform.position = startpos + distance;
        }
    }
}

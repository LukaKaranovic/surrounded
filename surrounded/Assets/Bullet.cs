using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float timeToLiveBullets = 2f;

    void Start()
    {
        Destroy(gameObject, timeToLiveBullets);;
    }

}

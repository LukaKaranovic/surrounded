using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.C0BU5
{
    public class C0BU5Spawns : MonoBehaviour
    {
        public GameObject C0BU5;

        private Camera mainCamera;

        // Start is called before the first frame update
        void Start()
        {
            mainCamera = Camera.main;
            StartCoroutine(C0BU5Spawn());
        }

        IEnumerator C0BU5Spawn()
        {
            yield return new WaitForSeconds(5);
            Vector3 spawnPosition = new Vector3(0f, 4f, 0f);
            GameObject COBUS = Instantiate(C0BU5, spawnPosition, Quaternion.identity);
            yield break;
        }

    }
}
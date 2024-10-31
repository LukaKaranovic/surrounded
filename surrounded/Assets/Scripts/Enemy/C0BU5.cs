using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C0BU5Boss : MonoBehaviour
{
    public GameObject C0BU5;
    private Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        StartCoroutine(C0BU5Spawn());
    }
    IEnumerator C0BU5Spawn(){
        yield return new WaitForSeconds(5);
        Vector2 spawnPosition = new Vector2(0f, 0f); // Get off-screen spawn position
        GameObject COBUS = Instantiate(C0BU5, spawnPosition, Quaternion.identity);
        yield break;
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}

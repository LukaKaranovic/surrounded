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
        Vector2 spawnPosition = new Vector2(0f, 1.5f); // Get off-screen spawn position
        GameObject COBUS = Instantiate(C0BU5, spawnPosition, Quaternion.identity);
    }
    Vector2 GetOffScreenPosition()
    {
        Vector2 screenMin = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 screenMax = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));

        float x, y;
        bool spawnOnX = Random.value > 0.5f;

        if (spawnOnX)
        {
            x = Random.value < 0.5f ? screenMin.x - 2 : screenMax.x + 2;
            y = Random.Range(screenMin.y, screenMax.y);
        }
        else
        {
            x = Random.Range(screenMin.x, screenMax.x);
            y = Random.value < 0.5f ? screenMin.y - 2 : screenMax.y + 2;
        }

        return new Vector2(x, y);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}

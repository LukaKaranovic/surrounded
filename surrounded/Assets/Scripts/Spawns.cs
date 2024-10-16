using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSpawner : MonoBehaviour
{
    public GameObject grunt;       // Assign Grunt ship prefab in the Inspector
    public GameObject viper;       // Assign Viper ship prefab in the Inspector
    public GameObject juggernaut;  // Assign Juggernaut ship prefab in the Inspector
    public GameObject striker;     // Assign Striker ship prefab in the Inspector
    public GameObject dreadnought;     // Assign Striker ship prefab in the Inspector

    public float spawnInterval = 5f;      // Time between spawns
    public Transform targetPoint;         // Target for ships to move towards (e.g., player ship)
    private int currentRound = 17;         // Track the current round

    private Camera mainCamera;            // Reference to the main camera

    void Start()
    {
        mainCamera = Camera.main;         // Get the main camera
        StartCoroutine(SpawnShips());
    }
    
    int GetCreditAmount(){
        return (int)(30*(Mathf.Pow(1.1f, (currentRound-1))));
    }

    IEnumerator SpawnShips()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            GameObject selectedShip = GetShipBasedOnRound();  // Select the ship type

            if (selectedShip != null)
            {
                Vector2 spawnPosition = GetOffScreenPosition();  // Get off-screen spawn position
                GameObject newShip = Instantiate(selectedShip, spawnPosition, Quaternion.identity);

                // Move the ship towards the target point
                MoveShipToTarget(newShip);
            }
        }
    }

    // Choose the appropriate ship prefab based on the current round
    GameObject GetShipBasedOnRound()
    {
        if (currentRound >= 15)
            return ChooseRandomShip(viper, juggernaut, striker, grunt, dreadnought);  
        else if (currentRound >= 10 && currentRound < 15)
            return ChooseRandomShip(viper, grunt, juggernaut, striker); 
        else if (currentRound >= 5 && currentRound < 10)
            return ChooseRandomShip(grunt, viper, juggernaut);
        else
            return ChooseRandomShip(grunt, viper); 
    }

    // Helper function to randomly select between given ship prefabs
    GameObject ChooseRandomShip(params GameObject[] ships)
    {
        return ships[Random.Range(0, ships.Length)];
    }

    // Get a random position just outside the camera's view
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

    // Move the ship towards the target point (e.g., player ship)
    void MoveShipToTarget(GameObject ship)
    {
        Vector2 targetPosition = targetPoint.position;
        float speed = Random.Range(2f, 5f);  // Randomize ship speed

        Rigidbody2D rb = ship.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = (targetPosition - (Vector2)ship.transform.position).normalized * speed;
        }
    }

    // Increment the round number
    public void IncrementRound()
    {
        currentRound++;
    }

}

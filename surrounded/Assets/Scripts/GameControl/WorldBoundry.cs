using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WorldBoundary : MonoBehaviour
{
   public GameOverScreen gameOverScreen;
   private PlayerController p;
   public GameObject player, comet;
   private Camera mainCamera;            // Reference to the main camera
   private bool isOutOfBounds = true;
   public TMP_Text warningText;

    void Start(){
        mainCamera = Camera.main;         // Get the main camera
    }
    void Update(){
        if(player!= null){
            float distance = Vector3.Distance (player.transform.position, transform.position);
            if(distance >= 550 && isOutOfBounds){
                StartCoroutine(Warning());
                isOutOfBounds = false;
            } else if( distance < 550){
                StopCoroutine(Warning());
                warningText.text = "";
                isOutOfBounds = true;
            }
        }
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

    IEnumerator Warning(){
        for(int i = 5; i>=0; i--){
            warningText.text = "WARNING: OUT OF BOUNDS.\n\n" + i.ToString() + " SECONDS BEFORE COMET DEPLOYMENT";
            yield return new WaitForSeconds(1);
        }
        if(!isOutOfBounds){
            Debug.Log("Comet INCOMING");
            comet = Instantiate(comet, GetOffScreenPosition(), Quaternion.identity);
            warningText.text = "";
        }
        yield break;
    }
}
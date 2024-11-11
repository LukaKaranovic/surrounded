using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossPortal : MonoBehaviour
{
    public float rotationSpeed;
    private Animator crossfade;
    private float transitionTime = 3f;
    void Start()
    {
        crossfade = GameObject.FindGameObjectWithTag("Crossfade").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            collider.GetComponent<PlayerController>().enabled = false; //Disable Player Controller on enter
            StartCoroutine(LoadBossScene());
        }
    }

    IEnumerator LoadBossScene()
    {
        crossfade.SetTrigger("PortalEnter");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("Boss");
    }
}
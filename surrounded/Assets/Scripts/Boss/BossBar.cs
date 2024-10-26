using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class BossBar : MonoBehaviour
{
    [SerializeField] protected Image bossBar;
    public TMP_Text bossText; 
    protected float currentHealth, maxHealth = 1000f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Boss());
    }

    // Update is called once per frame
    IEnumerator Boss()
    {
        float i = 0;
        int hp = 0;
        while(i <= 1){
            bossBar.fillAmount = i/1;
            i = i+0.1f;
            hp += 100;
            bossText.text = "C0B-U5: " + hp + "/1000";
            yield return new WaitForSeconds(.5f);
        }
    }
}

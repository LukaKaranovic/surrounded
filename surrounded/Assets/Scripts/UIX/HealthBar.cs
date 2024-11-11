using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public PlayerController player;
    [SerializeField] protected Image healthBar;
    protected float currentHealth, maxHealth;
    public TMP_Text healthText; 
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = player.stats.maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = player.health;
        if(currentHealth <=0){
            currentHealth = 0;
        }
        healthText.text = "HP: " + (int)(currentHealth + player.stats.shield) + "/" + maxHealth;
        float targetFillAmount = currentHealth/maxHealth;
        healthBar.fillAmount = targetFillAmount;
        maxHealth = player.stats.maxHealth;
    }
}

using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Player;

namespace UIX
{
    public class HealthBar : MonoBehaviour
    {
        public PlayerController player;
        [SerializeField] protected Image healthBar;
        protected float currentHealth, maxHealth;
        public TMP_Text healthText; 
        // Start is called before the first frame update
        void Start()
        {
            maxHealth = player.maxHealth;

        }

        // Update is called once per frame
        void Update()
        {
            currentHealth = player.health;
            if(currentHealth <=0){
                currentHealth = 0;
            }
            healthText.text = "HP: " + (int)(currentHealth + player.shield) + "/" + maxHealth;
            float targetFillAmount = currentHealth/maxHealth;
            healthBar.fillAmount = targetFillAmount;
            maxHealth = player.maxHealth;
        }
    }
}

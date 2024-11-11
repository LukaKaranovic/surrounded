namespace UIX
{
    public class ShieldBar : HealthBar
    {
        private float currentShield, maxShield;
        // Start is called before the first frame update
        void Start()
        {
            maxShield = player.shield;
            maxHealth = player.maxHealth;
        }

        // Update is called once per frame
        void Update()
        {
            currentShield = player.shield;
            if(currentShield <=0){
                currentShield = 0;
            }
            float targetFillAmount = currentShield/maxHealth;
            healthBar.fillAmount = targetFillAmount;
            maxShield = player.shield;
        }
    }
}

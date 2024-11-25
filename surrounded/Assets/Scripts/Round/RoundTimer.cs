using UnityEngine;
using TMPro;  // Import TextMeshPro namespace
using Player;
using UIX;

namespace Round {
    public class RoundTimer : MonoBehaviour
    {
        private float roundDuration = 55f;
        public float timer;
        public int round = 1;
        public TMP_Text timerText;
        public TMP_Text roundText;
        public GameOverScreen gameOverScreen;
        public PlayerController player;
        public UpgradeScreen upgrade;

        void Start()
        {
            timer = 55;
            UpdateRoundText();
        }

        void Update()
        {
            timer -= Time.deltaTime;

            if (timer <= 0f && gameOverScreen.gameOver == false)
            {
                IncrementRound();
                timer = roundDuration;
            }

            if (gameOverScreen.gameOver == false)
            {
                UpdateTimerText();
            }
            else
            {
                return;
            }
        }

    void IncrementRound()
    {
        player.health = player.stats.maxHealth;
        player.stats.shield = player.stats.maxShield;
        player.stats.score += 100;
        player.stats.score += round == 10 || round == 20 ? 400 : 0;
        round++;
        UpdateRoundText();
        upgrade.DisplayRandomUpgrades();
    }

        void UpdateTimerText()
        {
            timerText.text = "Time: " + Mathf.CeilToInt(timer).ToString();
        }

        void UpdateRoundText()
        {
            roundText.text = round.ToString();
        }
    }
}

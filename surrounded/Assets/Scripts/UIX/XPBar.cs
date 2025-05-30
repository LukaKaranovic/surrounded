using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Player;

namespace UIX
{
    public class XPBar : MonoBehaviour
    {
        public PlayerController p;
        [SerializeField] private Image XP;
        public TMP_Text XPText, GameOverScore, PauseMenuScore; 
        // Update is called once per frame
        void Update()
        {
        GameOverScore.text = PauseMenuScore.text = "Score: " + p.stats.score.ToString();
            XPText.text = p.stats.currentLevel.ToString();
            float targetFillAmount = p.stats.XP/p.levelReq;
            XP.fillAmount = targetFillAmount;


        }

    }
}
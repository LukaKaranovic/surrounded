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
        public TMP_Text XPText; 

        // Update is called once per frame
        void Update()
        {
            XPText.text = p.currentLevel.ToString();
            float targetFillAmount = p.XP/p.levelReq;
            XP.fillAmount = targetFillAmount;


        }

    }
}
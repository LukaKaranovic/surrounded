using System;
using System.Collections;
using GameControl;
using UnityEngine;
using TMPro;
using UIX;
using Unity.VisualScripting;
using Object = UnityEngine.Object;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine.InputSystem;

namespace Player
{
    public partial class PlayerController : MonoBehaviour
    {
        public Rigidbody2D rb;
        public Weapon weapon;
        public GameOverScreen gameOverScreen; // Reference to the GameOverScreen script
        public PauseMenu pauseMenu;
        public PlayerStats stats;
        public float health = 50f;
        public float levelReq = 30 * Mathf.Pow(1.1f, 0);
        public SpriteRenderer sprite, spritefield;
        public TMP_Text sstats, statsText; //stats for upgrade page and stats page

        private int MachineGunCount = 0,
            RocketBoosterCount = 0,
            divergeCount = 0,
            shieldCount = 0,
            forcefieldCount = 0,
            rouletteCount = 0;

        protected float nextFieldTime = 0f;
        protected int _timer;
        protected IEnumerator TimerCoroutine;
        private Action onTimeOut;
        public GameObject rouletteBall;

        Vector2 moveDirection;
        Vector2 mousePosition;
        
        Keyboard keyboard;

        private InputAction moveAction;

        void Start()
        {
            keyboard = Keyboard.current;
            moveAction = InputSystem.actions.FindAction("Move");
            stats.forceFieldActivated = stats.forcefieldCount > 0;
            LoadRoulette();
        }
        // Update is called once per frame

        void Update()
        {
            Color color = spritefield.color;
            color.a = stats.forceFieldActivated ? 1f : 0f; // 1 = fully visible, 0 = fully transparent
            spritefield.color = color;
            // Stats(); Dumped at the request of Quetzal to avoid a nullreference
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                pauseMenu.Pause();
            }

            //float moveX = Input.GetAxisRaw("Horizontal");
            //float moveY = Input.GetAxisRaw("Vertical");
            Vector2 moveValue = moveAction.ReadValue<Vector2>();
            

            if (Input.GetMouseButton(0))
            {
                if (stats.divergeCount > 0)
                {

                    weapon.Diverge(stats.divergeCount, stats.damage);

                }
                else
                {
                    weapon.Fire(stats.damage);
                }
            }

            moveDirection = moveValue.normalized;
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            stats.score = stats.XP;
            if (stats.XP >= levelReq)
            {
                stats.score += stats.XP;
                LevelUp();

            }
        }

        private void FixedUpdate()
        {
            rb.AddForce(stats.moveSpeed * new Vector2(moveDirection.x, moveDirection.y), ForceMode2D.Impulse);
            Vector2 aimDirection = mousePosition - rb.position;
            float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = aimAngle;
            if (health <= 0)
            {
                stats.ResetStats();
                gameOverScreen.Setup();
                Destroy(gameObject);
            }
        }

        public void takeDamage(float dam)
        {
            float damageTaken = (dam - stats.defense);
            if (damageTaken <= 1)
            {
                damageTaken = 1;
            }

            if (stats.forceFieldActivated)
            {
                damageTaken = 0;
                stats.forceFieldActivated = false;
                float time = 15 - (stats.forcefieldCount * 1.5f);
                if (time <= 2)
                {
                    time = 2;
                }

                this.ForceFieldTimerStart((int)time, () =>
                {
                    stats.forceFieldActivated = true;
                    onTimeOut = null;
                    Debug.Log("Callback lambda! Forcefield re-engaged.");
                });
            }

            if (stats.shield - damageTaken < 0)
            {
                health -= damageTaken - stats.shield;
                stats.shield = 0;
            }
            else
            {
                stats.shield -= damageTaken;
            }

            StartCoroutine(FlashRed());

            Debug.Log("Player taking damage! Health: " + health);
        }

        public void KillPlayer()
        {
            health = 0;
            stats.shield = 0;
        }

        private void LevelUp()
        {
            stats.damage += 1;
            stats.defense += 1;
            stats.baseSpeed += 1;
            stats.moveSpeed += 1;
            health += 10;
            stats.maxHealth += 10;
            if (stats.shieldCount != 0)
            {
                stats.maxShield = (0.1f + (0.05f * stats.shieldCount)) * stats.maxHealth;
            }

            stats.XP -= levelReq;
            stats.currentLevel++;
            levelReq = 30 * Mathf.Pow(1.1f, (stats.currentLevel - 1));

        }

        IEnumerator FlashRed()
        {
            sprite.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            sprite.color = Color.white;
        }


    }
}

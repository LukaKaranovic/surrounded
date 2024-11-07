using System;
using System.Collections;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using Object = UnityEngine.Object;

public partial class PlayerController : MonoBehaviour
{
    
    public Rigidbody2D rb;
    public Weapon weapon;
    public GameOverScreen gameOverScreen;     // Reference to the GameOverScreen script
    public PauseMenu pauseMenu;
    public float damage = 5f, defense = 3, moveSpeed = 10f, baseSpeed = 10f, health = 50, maxHealth = 50, XP = 0, shield = 0, maxShield;
    public int currentLevel = 1;
    public float levelReq = 30 * Mathf.Pow(1.1f, 0);
    public SpriteRenderer sprite, spritefield;
    private int MachineGunCount = 0, RocketBoosterCount = 0, divergeCount = 0, shieldCount = 0, forcefieldCount = 0, rouletteCount = 0;
    public TMP_Text sstats, stats; //stats for upgrade page and stats page
    public bool divergeActivated = false;
    public bool forceFieldActivated = false;
    protected float nextFieldTime = 0f;
    protected int _timer;
    protected IEnumerator TimerCoroutine;
    private Action onTimeOut;
    public GameObject rouletteBall;

    Vector2 moveDirection;
    Vector2 mousePosition;
    // Update is called once per frame
    void Update()
    {
        Color color = spritefield.color;
        color.a = forceFieldActivated ? 1f : 0f;  // 1 = fully visible, 0 = fully transparent
        spritefield.color = color;
        Stats();
        if(Input.GetKeyDown(KeyCode.Escape)){
            pauseMenu.Pause();
        }
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if(Input.GetMouseButton(0)){
            if(divergeActivated){

                weapon.Diverge(divergeCount, damage);

            } else{
                weapon.Fire(damage);
            }
        }

        moveDirection = new Vector2(moveX, moveY).normalized;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (XP >= levelReq) {
            LevelUp();

        }
    }

    private void FixedUpdate(){
        rb.AddForce(moveSpeed * new Vector2(moveDirection.x, moveDirection.y),ForceMode2D.Impulse);
        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }

    public void takeDamage(float dam) {
        float damageTaken = (dam - defense);
        if (damageTaken <= 1) {
            damageTaken = 1;
        }
        if (forceFieldActivated)
        {
            damageTaken = 0;
            forceFieldActivated = false;
            float time = 15-(forcefieldCount*1.5f);
            if(time <= 2){
                time = 2;
            }
            ForceFieldTimerStart((int)time, () =>
            {
                forceFieldActivated = true;
                onTimeOut = null;
                Debug.Log("Callback lambda! Forcefield re-engaged.");
            });
        }
        if(shield-damageTaken < 0){
            health -= damageTaken - shield;
            shield = 0;
        } else{
            shield -= damageTaken;
        }
        StartCoroutine(FlashRed());

        Debug.Log("Player taking damage! Health: " + health);
        if(health <= 0){
            gameOverScreen.Setup();
            FindObjectOfType<AudioManager>().Play("Player Death", 1.0f);
            Destroy(gameObject);
        }
    }
    public void KillPlayer()
    {
        health = 0;
        shield = 0;
        gameOverScreen.Setup();
        Destroy(gameObject);
    }
    private void LevelUp() {
        damage += 1;
        defense += 1;
        baseSpeed += 1;
        moveSpeed += 1;
        health += 10;
        maxHealth += 10;
        if(shieldCount != 0){
            maxShield = (0.1f+(0.05f*shieldCount))*maxHealth;
        }
        XP -= levelReq;
        currentLevel++;
        levelReq = 30 * Mathf.Pow(1.1f, (currentLevel-1));

    }

    IEnumerator FlashRed(){
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    }
}

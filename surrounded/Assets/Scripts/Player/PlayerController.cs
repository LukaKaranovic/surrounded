using System;
using System.Collections;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using Object = UnityEngine.Object;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Weapon weapon;
    public GameOverScreen gameOverScreen;     // Reference to the GameOverScreen script
    public PauseMenu pauseMenu;
    public float damage = 5f, defense = 3, moveSpeed = 10f, health = 50, maxHealth = 50, XP = 0, shield = 0, maxShield, baseSpeed = 10f;
    public int currentLevel = 1;
    public float levelReq = 30 * Mathf.Pow(1.1f, 0);
    public SpriteRenderer sprite;
    private int MachineGunCount = 0, RocketBoosterCount = 0, divergeCount = 0, shieldCount = 0;
    public TMP_Text sstats, stats; //stats for upgrade page and stats page
    public bool divergeActivated = false;
    public bool forceFieldActivated = false;
    protected float nextFieldTime = 0f;
    protected int _timer;
    protected IEnumerator TimerCoroutine;
    private Action onTimeOut;
    public UpgradeScreen itemsPoC;
    
    void Start(){
        itemsPoC.Items();
    }

    Vector2 moveDirection;
    Vector2 mousePosition;
    // Update is called once per frame
    void Update()
    {
        Stats();
        if(Input.GetKeyDown(KeyCode.Escape)){
            pauseMenu.Pause();
        }
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if(Input.GetMouseButton(0)){
            if(divergeActivated){
                weapon.Diverge(divergeCount);
            } else{
                weapon.Fire();
            }
        }

        moveDirection = new Vector2(moveX, moveY).normalized;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (XP >= levelReq) {
            LevelUp();

        }
    }

    private void FixedUpdate(){
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }

    public void takeDamage(float damage) {
        float damageTaken = (damage - defense);
        if (damageTaken <= 1) {
            damageTaken = 1;
        }
        if (forceFieldActivated)
        {
            damageTaken = 0;
            // don't take damage
            // drop sprite
            forceFieldActivated = false;
            ForceFieldTimerStart(15, () =>
            {
                // put the sprite back up
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
            Destroy(gameObject);
        }
    }

    private void LevelUp() {
        damage += 1;
        defense += 1;
        moveSpeed += 1;
        baseSpeed += 1;
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
    
    public void MachineGuns(){ //if machine guns upgrade collected
        if(MachineGunCount == 0){
            weapon.fireRate *= 1.1f;
        } else{
            weapon.fireRate = (1.1f+(0.05f*MachineGunCount)) * weapon.baseRate;
        }
        MachineGunCount++;
        }

    public void RocketBooster(){
        if(RocketBoosterCount == 0){
            moveSpeed *= 1.1f;
        } else{
            moveSpeed = (1.1f+(0.05f*RocketBoosterCount)) * baseSpeed;
        }
        RocketBoosterCount++;
    }

    public void PilotingEnhancement(){
        XP += levelReq;
        XP += levelReq;
    }

    public void DivergeActivated(){
        divergeActivated = true;
        divergeCount++;
    }

    public void Stats(){
        stats.text = "ATK: " + (int)damage + " DEF: " + (int)defense + " SPD: " + (int)moveSpeed;
        sstats.text = "ATK: " + (int)damage + " DEF: " + (int)defense + " SPD: " + (int)moveSpeed;
    }

    public void Shield(){   
        maxShield = (0.1f+(0.05f*shieldCount))*maxHealth;
        shieldCount++;
        shield = maxShield;
        moveSpeed = (1-(0.05f*shieldCount))*moveSpeed;    
    }

    public void ForceField()
    {
        forceFieldActivated = true;
        // TODO: raise forcefield sprite
    }

    public IEnumerator forceFieldTimer(int totaltime)
    {
        while (_timer < totaltime)
        {
            yield return new WaitForSecondsRealtime(1);
            _timer++;
            Debug.Log("forcefield timer at " + _timer);
        }
        
        // trigger callback
        onTimeOut?.Invoke();
    }

    public void ForceFieldTimerStart(int totalTime, Action timeOut)
    {
        onTimeOut = timeOut; // save callback Action
        // reset timer
        _timer = 0;
        TimerCoroutine = forceFieldTimer(15);
        StartCoroutine(TimerCoroutine);
    }
    
}

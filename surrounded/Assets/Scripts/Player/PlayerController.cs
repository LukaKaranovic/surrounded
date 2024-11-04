using System;
using System.Collections;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using Object = UnityEngine.Object;
using Unity.VisualScripting.Antlr3.Runtime.Misc;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Weapon weapon;
    public GameOverScreen gameOverScreen;     // Reference to the GameOverScreen script
    public PauseMenu pauseMenu;
    public PlayerStats stats;
    public float health = 50f;
    public float levelReq = 30 * Mathf.Pow(1.1f, 0);
    public SpriteRenderer sprite, spritefield;
    public TMP_Text sstats, statsText; //stats for upgrade page and stats page
    public bool divergeActivated = false;
    public bool forceFieldActivated = false;

    protected float nextFieldTime = 0f;
    protected int _timer;
    protected IEnumerator TimerCoroutine;
    private Action onTimeOut;
    public GameObject rouletteBall;

    Vector2 moveDirection;
    Vector2 mousePosition;

    //Boundary Implementation Variables (Added 2024/11/03 By Casey, used for boundaries on boss scene
    // to interact with collisions)

    //public GameObject topRightLimitGameobject;
    //public GameObject bottomLeftLimitGameobject;

    //private Vector3 topRightLimit;
    //private Vector3 bottomLeftLimit;

    //private Vector2 input;

    //void Start()
    //{
    //   topRightLimit = topRightLimitGameobject.transform.position;
    //   bottomLeftLimit = bottomLeftLimitGameobject.transform.position;

    //}

    //scrapped implementation for now


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

                weapon.Diverge(stats.divergeCount, stats.damage);

            } else{
                weapon.Fire(stats.damage);
            }
        }

        moveDirection = new Vector2(moveX, moveY).normalized;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        stats.score = stats.XP;
        if (stats.XP >= levelReq) {
            stats.score += stats.XP;
            LevelUp();

        }
    }

    private void FixedUpdate(){
        rb.AddForce(stats.moveSpeed * new Vector2(moveDirection.x, moveDirection.y),ForceMode2D.Impulse);
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

    public void takeDamage(float dam) {
        float damageTaken = (dam - stats.defense);
        if (damageTaken <= 1) {
            damageTaken = 1;
        }
        if (forceFieldActivated)
        {
            damageTaken = 0;
            forceFieldActivated = false;
            float time = 15-(stats.forcefieldCount * 1.5f);
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
        if(stats.shield - damageTaken < 0){
            health -= damageTaken - stats.shield;
            stats.shield = 0;
        } else{
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

    private void LevelUp() {
        stats.damage += 1;
        stats.defense += 1;
        stats.baseSpeed += 1;
        stats.moveSpeed += 1;
        health += 10;
        stats.maxHealth += 10;
        if(stats.shieldCount != 0){
            stats.maxShield = (0.1f+(0.05f* stats.shieldCount))* stats.maxHealth;
        }
        stats.XP -= levelReq;
        stats.currentLevel++;
        levelReq = 30 * Mathf.Pow(1.1f, (stats.currentLevel - 1));

    }

    IEnumerator FlashRed(){
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    }
    
    public void MachineGuns(){ //if machine guns upgrade collected
        if(stats.MachineGunCount == 0){
            weapon.fireRate *= 1.1f;
        } else{
            weapon.fireRate = (1.1f+(0.05f* stats.MachineGunCount)) * weapon.baseRate;
        }
        stats.MachineGunCount++;
        }

    public void RocketBooster(){
        if(stats.RocketBoosterCount == 0){
            stats.moveSpeed *= 1.1f;
        } else{
            stats.moveSpeed = (1.1f+(0.05f* stats.RocketBoosterCount)) * stats.baseSpeed;
        }
        stats.RocketBoosterCount++;
    }

    public void PilotingEnhancement(){
        stats.XP += levelReq;
        stats.XP += levelReq;
    }
    
    public void DivergeActivated(){
        divergeActivated = true;
        stats.divergeCount++;
    }

    public void Stats(){
        statsText.text = "ATK: " + (int)stats.damage + " DEF: " + (int)stats.defense + " SPD: " + (int)stats.moveSpeed;
        sstats.text = "ATK: " + (int)stats.damage + " DEF: " + (int)stats.defense + " SPD: " + (int)stats.moveSpeed;
    }

    public void Shield(){
        stats.maxShield = (0.1f+(0.05f* stats.shieldCount))* stats.maxHealth;
        stats.shieldCount++;
        stats.shield = stats.maxShield;
        stats.moveSpeed = (1-(0.05f* stats.shieldCount))* stats.moveSpeed;
    }

    public void ForceField()
    {
        forceFieldActivated = true;
        stats.forcefieldCount++;
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
        TimerCoroutine = forceFieldTimer(totalTime);
        StartCoroutine(TimerCoroutine);
    }
    public void Roulette(){
        stats.rouletteCount++;
        if(stats.rouletteCount > 3){
            stats.rouletteCount = 3;
        }
        GameObject roulette = Instantiate(rouletteBall);
        Roulette r = roulette.GetComponent<Roulette>();
        switch(stats.rouletteCount){
            case 1: 
                r.isBall1 = true;
                break;
            case 2:
                r.isBall2 = true;
                break;
            case 3:
                r.isBall3 = true;
                break;
        }
    }
}

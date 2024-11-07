using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public StatsPage statsPage; //Retrieve Stats and Upgrades Page in order to activate and deactivate
    public bool isStatsOpen = false;
    public PlayerStats playerStats;
    public void Pause(){ //pauses game
        gameObject.SetActive(true);
        Time.timeScale = 0; //means time is paused
    }

    public void Resume(){ //resumes game
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    public void Stats(){ //opens stats and upgrades page
        statsPage.Setup();
        isStatsOpen = true;
        Time.timeScale = 0;
        }
    public void Restart(){
        playerStats.ResetStats();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //reloads game - restarts
        Time.timeScale = 1;
    }
    public void Quit(){ //quits game
        playerStats.ResetStats();
        SceneManager.LoadScene("Main Menu");       
        Time.timeScale = 1;
    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape) && !isStatsOpen){ //if press esc and stats page isnt open, then resume game, otherwise removes stat page off screen
            Resume();
        } else if(Input.GetKeyDown(KeyCode.Escape)){
            statsPage.Resume();
            isStatsOpen = false;
        }
    }
}

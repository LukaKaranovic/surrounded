using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UpgradeScreen : MonoBehaviour
{
    public Sprite[] upgrades; //array for 8 upgrade sprites
    private string[] upgradeDesc = { //descriptions for the 8 upgrades from reqs
        "Diverge: Fires 3 bullets in a cone, +10% damage per stack",
        "Forcefield: Automatically dodges 1 hit, 15s cooldown (-10% per stack)",
        "Fortified Plating: Adds shield health and +10% max health per stack. Shield regenerates only between rounds.",
        "Machine Guns: Increases fire rate by 10% (+5% per stack).",
        "Piercing Rounds: Shots hit 2 enemies (+1 per stack)",
        "Piloting Enhancements: Grants 2 free level-ups (one-time use)",
        "Rocket Boosters: Boosts movement speed by 10% (+5% per stack)",
        "Roulette: Spawns damaging orbs (max 3), +1 orb per stack. Orbs deal 2x player’s damage"
    };
    public Image[] uiImage;//where to display images
    public TMP_Text[] uiDescriptions;//where to display descriptions
    public Button[] uiButtons; 
    private int[] displayedUpgrades = new int[3];
    public PlayerController player; //for upgrades

    public void DisplayRandomUpgrades() //function chooses random images to put on screen
    {

        gameObject.SetActive(true);
        Time.timeScale = 0;
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (GameObject bullet in bullets){
            Destroy(bullet);
        }
        GameObject[] ships = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject ship in ships){
            Destroy(ship);
        }
        // Create a list of available indices (0 to 7)
        int[] list = { 0, 1, 2, 3, 4, 5, 6, 7};

        // Shuffle the list randomly
        Shuffle(list);

        // Assign the first 3 images and descriptions to the UI elements
        for (int i = 0; i < 3; i++)
        {
            int randomIndex = list[i];
            displayedUpgrades[i] = randomIndex;
            uiImage[i].sprite = upgrades[randomIndex];
            uiDescriptions[i].text = upgradeDesc[randomIndex];
            int index = i; 
            uiButtons[i].onClick.AddListener(() => ApplyUpgrade(displayedUpgrades[index]));
        }
    }

    // Helper function to shuffle a list
    void Shuffle(int[] arr)
    {
        for (int i = arr.Length - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            int temp = arr[i];
            arr[i] = arr[randomIndex];
            arr[randomIndex] = temp;
        }
    }

    private void ApplyUpgrade(int index){
        //Import all upgrade functions here based on index
        /*index to upgrade list:
            0: Diverge
            1: Forcefield
            2: Fortified Plating
            3: Machine Guns
            4: Piercing Rounds
            5: Piloting Enhancements
            6: Rocket Boosters
            7: Roulette
            */
        switch (index){
            case 0:
                //Diverge
                Debug.Log("0");
                break;
            case 1:
                //Forcefield
                Debug.Log("1");
                break;
            case 2:
                //Fortified Plating
                Debug.Log("2");
                break;
            case 3:
                //Machine Guns
                player.MachineGuns();
                Debug.Log("3");
                break;
            case 4: 
                //Piercing Round
                Debug.Log("4");
                break;
            case 5:
                //Piloting Enhancements
                player.PilotingEnhancement();
                Debug.Log("5");
                break;
            case 6:
                //Rocket Boosters
                player.RocketBooster();
                Debug.Log("6");
                break;
            case 7:
                //Roulette
                Debug.Log("7");
                break;
        }
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}

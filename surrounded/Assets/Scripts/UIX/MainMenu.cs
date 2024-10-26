using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public void BossButton(){
        SceneManager.LoadScene("Bosses");
    }
    public void ItemButton(){
        SceneManager.LoadScene("Items");
    }
    public void EnemyButton(){
        SceneManager.LoadScene("Enemies");
    }
    public void BoundaryButton(){
        SceneManager.LoadScene("World Boundary");
    }
    public void QuitButton(){
        Application.Quit();
    }
}

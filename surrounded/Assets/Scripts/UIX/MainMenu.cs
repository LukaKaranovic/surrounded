using UnityEngine;
using UnityEngine.SceneManagement;

namespace UIX
{
    public class MainMenu : MonoBehaviour
    {
        public void PlayButton(){
            SceneManager.LoadScene("Game");
        }
        public void QuitButton(){
            Application.Quit();
        }
    }
}

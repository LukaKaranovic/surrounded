using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using GameControl;
using Player;
using Round;

namespace Tests
{
    public class RND01 : InputTestFixture
    {
        private Keyboard keyboard;
        private Mouse mouse;
        private GameObject[] Enemies;
        
        [SetUp]
        public new void Setup()
        {
            SceneManager.LoadScene("Scenes/Game"); // load game scene
            keyboard = InputSystem.AddDevice<Keyboard>();
            mouse = InputSystem.AddDevice<Mouse>();
        }
    
        // A UnityTest behaves like a coroutine in PlayMode
        // and allows you to yield null to skip a frame in EditMode
        [UnityTest]
        public IEnumerator RND01WithEnumeratorPasses()
        {
            Time.timeScale = 5;
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            PlayerController pc = player.GetComponent<PlayerController>();
            Assert.That(player, !Is.Null);
            GameObject RT = GameObject.Find("Canvas/Timer");
            RoundTimer timer = RT.GetComponent<RoundTimer>();
            if(Mathf.CeilToInt(timer.timer) == 49){
                Enemies = GameObject.FindGameObjectsWithTag("Enemy");
                Assert.AreEqual(Enemies.Length, 0);
            }
            yield return new WaitForSeconds(5);
            Enemies = GameObject.FindGameObjectsWithTag("Enemy");
            Assert.AreEqual(Enemies.Length, 3);
        }
    }
}
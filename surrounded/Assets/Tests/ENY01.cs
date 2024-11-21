using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using GameControl;
using Player;
using Enemy;


namespace Tests
{
    public class ENY01 : InputTestFixture

    {
        private Keyboard keyboard;
        private Mouse mouse;
        public bool enemiesAlive = false;

        [SetUp]
        public new void Setup()
        {
            SceneManager.LoadScene("Scenes/Game"); // load game scene
            keyboard = InputSystem.AddDevice<Keyboard>();
            mouse = InputSystem.AddDevice<Mouse>();

        }

        [UnityTest]
        public IEnumerator ENY01WithEnumeratorPasses() 
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            PlayerController pc = player.GetComponent<PlayerController>();
            Assert.That(player, !Is.Null);
            GameObject RT = GameObject.Find("Canvas/Timer");
            RoundTimer timer = RT.GetComponent<RoundTimer>();
            Enemies = GameObject.FindGameObjectsWithTag("Enemy");
            Assert.That(player, !Is.Null);
            if (Enemies != null) 
            {
                enemiesAlive = true;
                Assert.IsNotNull(Enemy);
            }
            yield return new WaitForSeconds(5);
            Assert.That(Enemies = null);

        }

    }
}

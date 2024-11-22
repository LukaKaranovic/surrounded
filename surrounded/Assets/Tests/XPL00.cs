using System.Collections;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using GameControl;
using Player;
using Enemy;
using Round;

namespace Tests
{
    public class XPL00 : InputTestFixture

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
        public IEnumerator XPL00WithEnumeratorPasses() 
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            PlayerController pc = player.GetComponent<PlayerController>();
            Assert.That(player, !Is.Null);
            pc.stats.XP = 0; // reset this
            yield return new WaitForSeconds(6);
            GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (var enemy in Enemies)
            {
                enemy.GetComponent<EnemyController>().takeDamage(50);
            }

            yield return new WaitForSeconds(1);
            Assert.That(pc.stats.XP, Is.EqualTo(3f));
        }

    }
}

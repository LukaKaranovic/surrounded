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
            GameObject spawns = GameObject.Find("ShipSpawns");
            ShipSpawner pos = spawns.GetComponent<ShipSpawner>();
            yield return new WaitForSeconds(5);
            GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
            GameObject enemy = Enemies.Last();
            Assert.AreEqual(pos.spawnPosition.x, enemy.transform.position.x);
            Assert.AreEqual(pos.spawnPosition.y, enemy.transform.position.y);
            
        }

    }
}

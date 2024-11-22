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
            yield return new WaitForSeconds(5);
            GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
            GameObject enemy = Enemies.Last();
            GameObject spawns = GameObject.Find("ShipSpawns");
            ShipSpawner pos = spawns.GetComponent<ShipSpawner>();
            //EnemyController ec = enemy.GetComponent<EnemyController>();
            pos.spawnInterval = 100f;
            foreach(GameObject e in Enemies){
                EnemyController ec = e.GetComponent<EnemyController>();
                while(ec.health > 0){
                    Vector2 aimDirection = e.transform.position - player.transform.position;
                    float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
                    player.transform.rotation = Quaternion.Euler(0, 0, aimAngle);
                    pc.weapon.Fire(50f);
                    yield return new WaitForSeconds(0.2f);
                }
            }
            Assert.AreEqual(pc.stats.XP, 3);
        }

    }
}

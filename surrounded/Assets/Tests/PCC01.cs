using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using GameControl;
using Player;

namespace Tests
{
    public class PCC01 : InputTestFixture
    {
        
        [SetUp]
        public new void Setup()
        {
            SceneManager.LoadScene("Scenes/Game"); // load game scene
        }

        // A UnityTest behaves like a coroutine in PlayMode
        // and allows you to yield null to skip a frame in EditMode
        [UnityTest]
        public IEnumerator PCC01WithEnumeratorPasses()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            PlayerController pc = player.GetComponent<PlayerController>();
            Assert.That(player, !Is.Null);
            pc.weapon.Fire(5f);
            yield return new WaitForSeconds(1);
            GameObject bullet = GameObject.FindGameObjectWithTag("Bullet");
            Assert.That(bullet, !Is.Null);
        }

        [TearDown]
        public override void TearDown()
        {
            base.TearDown();
        }
    }
    
        
}
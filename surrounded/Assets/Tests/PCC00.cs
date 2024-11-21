using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.InputSystem;

namespace Tests
{
    public class PCC00 : InputTestFixture
    {
        private Keyboard keyboard;
        
        [SetUp]
        public new void Setup()
        {
            SceneManager.LoadScene("Scenes/Game"); // load game scene
            keyboard = InputSystem.AddDevice<Keyboard>();
            var mouse = InputSystem.AddDevice<Mouse>(); // if this is removed, things break
        }

        [Test]
        public void TestPlayerInstantiation()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Assert.That(player, !Is.Null);
        }

        // PCC00: Player Movement Test
        [UnityTest]
        public IEnumerator PCC00Passes()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Vector3 initpos = player.transform.position;
            Press(keyboard.wKey);
            yield return new WaitForSeconds(1);
            Release(keyboard.wKey);
            Vector3 finalpos = player.transform.position;
            
            Assert.That(initpos, Is.Not.EqualTo(finalpos));
        }
    }
}
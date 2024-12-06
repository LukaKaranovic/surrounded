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
    public class MAT01 : InputTestFixture
    {
        private Keyboard keyboard;
        private Mouse mouse;
        
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
        public IEnumerator MAT01WithEnumeratorPasses()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            PlayerController pc = player.GetComponent<PlayerController>();
            Assert.That(player, !Is.Null);
            for(int i = 545; i<555; i++){
                player.transform.position = new Vector3(0, i, 0);
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(8.5f);
            Assert.AreEqual(pc.health, 0);
        }
    }
}
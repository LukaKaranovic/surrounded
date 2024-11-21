using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using GameControl;

namespace Tests
{
    public class PCC01 : InputTestFixture
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
        public IEnumerator PCC01WithEnumeratorPasses()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Assert.That(player, !Is.Null);
            mouse.WarpCursorPosition(new Vector2(0, 10));
            Press(mouse.leftButton);
            yield return new WaitForSeconds(1);
            Release(mouse.leftButton);
            GameObject bullet = GameObject.FindGameObjectWithTag("Bullet");
            Assert.That(bullet, !Is.Null);
        }
    }
}
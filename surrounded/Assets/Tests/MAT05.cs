using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.InputSystem;
using Player;

namespace Tests
{
    public class MAT05 : InputTestFixture
    {
        private Keyboard keyboard;
        
        [SetUp]
        public new void Setup()
        {
            SceneManager.LoadScene("Scenes/Game"); // load game scene
            keyboard = InputSystem.AddDevice<Keyboard>();
            var mouse = InputSystem.AddDevice<Mouse>(); // if this is removed, things break
        }

        //MAT05
        [UnityTest]
        public IEnumerator MAT05WithEnumeratorPasses()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            PlayerController pc = player.GetComponent<PlayerController>();
            Press(keyboard.wKey);
            yield return new WaitForSeconds(2);
            Release(keyboard.wKey);
            yield return new WaitForSeconds(2);
            Vector2 pTrans = new Vector2(player.transform.position.x, player.transform.position.y); //vector2 of Player Position    
            Vector2 camTrans = new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.y); //vector2 of Camera Position
            Assert.AreEqual(pTrans.x, camTrans.x, 0.5); // check both axes are equal, with a tolerance of .5 units
            Assert.AreEqual(pTrans.y, camTrans.y, 0.5);
        }
    }
}
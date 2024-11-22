using UnityEngine;
using Player;
using GameControl;
using NUnit.Framework;
using TMPro;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class PCC03
    {

        [SetUp]
        public void Setup()
        {
            SceneManager.LoadScene("Scenes/Game");
        }
        // A UnityTest behaves like a coroutine in PlayMode
        // and allows you to yield null to skip a frame in EditMode
        [UnityEngine.TestTools.UnityTest]
        public System.Collections.IEnumerator PCC03TestWithEnumeratorPasses()
        {
             // only necessary for play mode tests
            /*GameObject newcam = new GameObject("newMainCam");
            newcam.AddComponent<Camera>();
            newcam.tag = "MainCamera";
            PlayerStats s = ScriptableObject.CreateInstance<PlayerStats>();
            s.ResetStats(); // give player a Stats object*/
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Assert.That(player, !Is.Null);
            GameObject bullet = GameObject.Instantiate(Resources.Load("Prefab/PiercingBullet"),
                new Vector3(player.transform.position.x, player.transform.position.y + 3), Quaternion.identity) as GameObject;
            Assert.That(bullet, !Is.Null);
            bullet.GetComponent<Bullet>().damage = 1;
            bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.down * 4, ForceMode2D.Impulse);
            yield return new WaitForSeconds(4);
            Assert.That(player.GetComponent<PlayerController>().health 
                        < player.GetComponent<PlayerController>().stats.maxHealth, Is.True);
            yield return true;
        }
    }
}
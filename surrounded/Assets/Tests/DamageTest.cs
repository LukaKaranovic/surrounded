using UnityEngine;
using Player;
using GameControl;
using NUnit.Framework;
using TMPro;

namespace Tests
{
    public class DamageTest
    {
        // A UnityTest behaves like a coroutine in PlayMode
        // and allows you to yield null to skip a frame in EditMode
        [UnityEngine.TestTools.UnityTest]
        public System.Collections.IEnumerator DamageTestWithEnumeratorPasses()
        {
             // only necessary for play mode tests
            /*GameObject newcam = new GameObject("newMainCam");
            newcam.AddComponent<Camera>();
            newcam.tag = "MainCamera";
            PlayerStats s = ScriptableObject.CreateInstance<PlayerStats>();
            s.ResetStats(); // give player a Stats object*/
            
            GameObject player = GameObject.Instantiate(Resources.Load("Prefab/Player Ship"),
                Vector2.zero,
                Quaternion.identity)
                as GameObject;
            Assert.That(player, !Is.Null);
            GameObject bullet = GameObject.Instantiate(Resources.Load("Prefab/PiercingBullet"),
                new Vector3(player.transform.position.x, player.transform.position.y + 3), Quaternion.identity) as GameObject;
            Assert.That(bullet, !Is.Null);
            bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.down, ForceMode2D.Impulse);
            yield return new WaitForSeconds(4);
            Assert.That(player.GetComponent<PlayerController>().health 
                        < player.GetComponent<PlayerController>().stats.maxHealth);
            yield return true;
        }
    }
}
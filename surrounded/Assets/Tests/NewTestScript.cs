using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using NUnit.Framework;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.TestTools;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;

public class NewTestScript
{
    // A Test behaves as an ordinary method
    [Test]
    public void NewTestScriptSimplePasses()
    {
        // Use the Assert class to test conditions
    }
    [UnityTest]
    public IEnumerator testPlayerDamage()
    {
        GameObject player =
            GameObject.Instantiate(Resources.Load("Prefab/Player Ship"),
                Vector2.zero,
                Quaternion.identity
            ) as GameObject;
        Assert.That(player, !Is.Null);

        GameObject bullet = GameObject.Instantiate(Resources.Load("Prefab/PiercingBullet"),
            new Vector2(0, 10),
            Quaternion.identity) as GameObject;
        Assert.That(bullet, !Is.Null);
        
        Assert.That(player.GetComponent<Player);
        bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.down, ForceMode2D.Impulse);
    }
}

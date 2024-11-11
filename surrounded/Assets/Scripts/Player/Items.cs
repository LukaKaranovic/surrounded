using UnityEngine;
using System;
using System.Collections;
using TMPro;
using Object = UnityEngine.Object;

namespace Player
{
    public partial class PlayerController
    {
        public void MachineGuns()
        {
            //if machine guns upgrade collected
            if (MachineGunCount == 0)
            {
                weapon.fireRate *= 1.1f;
            }
            else
            {
                weapon.fireRate = (1.1f + (0.05f * MachineGunCount)) * weapon.baseRate;
            }

            MachineGunCount++;
        }

        public void RocketBooster()
        {
            if (RocketBoosterCount == 0)
            {
                moveSpeed *= 1.1f;
            }
            else
            {
                moveSpeed = (1.1f + (0.05f * RocketBoosterCount)) * baseSpeed;
            }

            RocketBoosterCount++;
        }

        public void PilotingEnhancement()
        {
            XP += levelReq;
            XP += levelReq;
        }

        public void DivergeActivated()
        {
            divergeActivated = true;
            divergeCount++;
        }

        public void Stats()
        {
            stats.text = "ATK: " + (int)damage + " DEF: " + (int)defense + " SPD: " + (int)moveSpeed;
            sstats.text = "ATK: " + (int)damage + " DEF: " + (int)defense + " SPD: " + (int)moveSpeed;
        }

        public void Shield()
        {
            maxShield = (0.1f + (0.05f * shieldCount)) * maxHealth;
            shieldCount++;
            shield = maxShield;
            moveSpeed = (1 - (0.05f * shieldCount)) * moveSpeed;
        }

        public void ForceField()
        {
            forceFieldActivated = true;
            forcefieldCount++;
        }

        public IEnumerator forceFieldTimer(int totaltime)
        {
            while (_timer < totaltime)
            {
                yield return new WaitForSecondsRealtime(1);
                _timer++;
                Debug.Log("forcefield timer at " + _timer);
            }

            // trigger callback
            onTimeOut?.Invoke();
        }

        public void ForceFieldTimerStart(int totalTime, Action timeOut)
        {
            onTimeOut = timeOut; // save callback Action
            // reset timer
            _timer = 0;
            TimerCoroutine = forceFieldTimer(totalTime);
            StartCoroutine(TimerCoroutine);
        }

        public void Roulette()
        {
            rouletteCount++;
            if (rouletteCount > 3)
            {
                rouletteCount = 3;
            }

            GameObject roulette = Instantiate(rouletteBall);
            Roulette r = roulette.GetComponent<Roulette>();
            switch (rouletteCount)
            {
                case 1:
                    r.isBall1 = true;
                    break;
                case 2:
                    r.isBall2 = true;
                    break;
                case 3:
                    r.isBall3 = true;
                    break;
            }
        }

        public void Piercing()
        {
            var piercingbull = Resources.Load("PiercingBullet") as GameObject; // load piercingbullet prefab
            weapon.bulletPrefab = piercingbull; // assign prefab
        }
    }
}
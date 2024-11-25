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
            if (stats.MachineGunCount == 0)
            {
                weapon.fireRate *= 1.1f;
            }
            else
            {
                weapon.fireRate = (1.1f + (0.05f * MachineGunCount)) * weapon.baseRate;
            }

            MachineGunCount++;
        }

        public void PilotingEnhancement()
        {
            stats.XP += levelReq;
            stats.XP += levelReq;
        }

        public void Diverge()
        {
            stats.divergeActivated = true;
            divergeCount++;
        }

        public void Stats()
        {
            statsText.text = "ATK: " + (int)stats.damage + " DEF: " + (int)stats.defense + " SPD: " +
                             (int)stats.moveSpeed;
            sstats.text = "ATK: " + (int)stats.damage + " DEF: " + (int)stats.defense + " SPD: " + (int)stats.moveSpeed;
        }

        public void Shield()
        {
            stats.maxShield = (0.1f + (0.05f * shieldCount)) * stats.maxHealth;
            shieldCount++;
            stats.shield = stats.maxShield;
            stats.moveSpeed = (1 - (0.05f * shieldCount)) * stats.moveSpeed;
        }

        public void ForceField()
        {
            stats.forceFieldActivated = true;
            forcefieldCount++;
        }

        public void RocketBooster()
        {
            if (RocketBoosterCount == 0)
            {
                stats.moveSpeed *= 1.1f;
            }
            else
            {
                stats.moveSpeed = (1.1f + (0.05f * RocketBoosterCount)) * stats.baseSpeed;
            }

            RocketBoosterCount++;
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

        //Used in start method to instantiate roulette objects using roulette count stat
        private void LoadRoulette()
        {
            for (int i = 0; i < stats.rouletteCount; i++)
            {
                GameObject roulette = Instantiate(rouletteBall);
                Roulette r = roulette.GetComponent<Roulette>();
                switch (i)
                {
                    case 0:
                        r.isBall1 = true;
                        break;
                    case 1:
                        r.isBall2 = true;
                        break;
                    case 2:
                        r.isBall3 = true;
                        break;
                }
            }
        }
    }
}
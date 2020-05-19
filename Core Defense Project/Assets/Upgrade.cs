using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Stats {LIFE,FIRERATE,DAMAGE,BULLETSPEED }
public class Upgrade : MonoBehaviour
{
    public Sprite emptyUpgrade;
    public Sprite fillUpgrade;

    public int satelite;
    public int shockWave;
    public int missileBullet;

    public void buySatelite()
    {
        satelite++;
        GameObject.FindGameObjectWithTag("Engine").GetComponent<Engine>().SpawnSatellite(satelite);
    }

    public void UpgradeStats(Stats stat)
    {
        switch (stat)
        {
            case Stats.LIFE:
                break;
            case Stats.FIRERATE:
                break;
            case Stats.DAMAGE:
                break;
            case Stats.BULLETSPEED:
                break;
            default:
                break;
        }


    }
}

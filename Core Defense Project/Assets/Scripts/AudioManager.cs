using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public enum Sounds {ENEMYHIT,PLAYERHIT,COLLECT,ENEMYDEAD,SELECT,UPGRADE,SHOOT,MISSILE}
public class AudioManager : MonoBehaviour
{
    public AudioClip enemyHit;
    public AudioClip playerHit;
    public AudioClip collect;
    public AudioClip enemyDead;
    public AudioClip select;
    public AudioClip upgrade;
    public AudioClip shoot;
    public AudioClip missile;

    public AudioClip music1;
    public AudioClip music2;
    public AudioClip music3;

    public void Start()
    {
        int r = Random.Range(0, 3);
        switch (r)
        {
            case 0:
                GetComponent<AudioSource>().clip = music1;
                break;
            case 1:
                GetComponent<AudioSource>().clip = music2;
                break;
            case 2:
                GetComponent<AudioSource>().clip = music3;
                break;
        }

        GetComponent<AudioSource>().Play();

    }

    public void PlaySound(Sounds sound)
    {
        switch (sound)
        {
            case Sounds.ENEMYHIT:
                GetComponent<AudioSource>().PlayOneShot(enemyHit);
                break;
            case Sounds.PLAYERHIT:
                GetComponent<AudioSource>().PlayOneShot(playerHit);
                break;
            case Sounds.COLLECT:
                GetComponent<AudioSource>().PlayOneShot(collect);
                break;
            case Sounds.ENEMYDEAD:
                GetComponent<AudioSource>().PlayOneShot(enemyDead);
                break;
            case Sounds.SELECT:
                GetComponent<AudioSource>().PlayOneShot(select);
                break;
            case Sounds.UPGRADE:
                GetComponent<AudioSource>().PlayOneShot(upgrade);
                break;
            case Sounds.SHOOT:
                GetComponent<AudioSource>().PlayOneShot(shoot);
                break;
            case Sounds.MISSILE:
                GetComponent<AudioSource>().PlayOneShot(missile);
                break;
            default:
                break;
        }
    }

    public void PlaySelect()
    { 
                GetComponent<AudioSource>().PlayOneShot(select);
    }
}

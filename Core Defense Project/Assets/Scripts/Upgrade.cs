using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    public Player player;

    public Sprite emptyUpgrade;
    public Sprite fillUpgrade;

    public int lifeUpgrade;
    public Image[] lifeSprites;
    public int fireRateUpgrade;
    public Image[] fireRateSprites;
    public int damageUpgrade;
    public Image[] damageSprites;
    public int bulletSpeedUpgrade;
    public Image[] bulletSpeedSprites;

    public int satelite;
    public Image[] sateliteSprites;
    public int shockWave;
    public Image[] shockWaveSprites;
    public int missileBullet;
    public Image[] missileBulletSprites;
    public bool laser;
    public Image laserSprite;


    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void UpdateUpgrade()
    {
        for (int i = 0; i < lifeUpgrade; i++)
        {
            lifeSprites[i].sprite = fillUpgrade;
        }

        for (int i = 0; i < fireRateUpgrade; i++)
        {
            fireRateSprites[i].sprite = fillUpgrade;
        }

        for (int i = 0; i < damageUpgrade; i++)
        {
            damageSprites[i].sprite = fillUpgrade;
        }

        for (int i = 0; i <  bulletSpeedUpgrade; i++)
        {
            bulletSpeedSprites[i].sprite = fillUpgrade;
        }

        GameObject.FindGameObjectWithTag("Engine").GetComponent<AudioManager>().PlaySound(Sounds.UPGRADE);
    }

    public void buySatelite()
    {
        satelite++;
        GameObject.FindGameObjectWithTag("Engine").GetComponent<Engine>().SpawnSatellite(satelite);
    }

    public void UpgradeStats(int stat)
    {
        switch (stat)
        {
            case 1:
                if (lifeUpgrade == lifeSprites.Length)
                    break;
                player.maxLife += 2;
                lifeUpgrade++;
                player.Heal(player.maxLife-player.currentLife);
                break;
            case 2:
                if (fireRateUpgrade == fireRateSprites.Length)
                    break;
                player.fireRate = player.fireRate / 10;
                fireRateUpgrade++;
                break;
            case 3:
                if (damageUpgrade == damageSprites.Length)
                    break;
                player.bulletDamage++;
                damageUpgrade++;
                break;
            case 4:
                if (bulletSpeedUpgrade == bulletSpeedSprites.Length)
                    break;
                player.cannonSpeed+= 100;
                bulletSpeedUpgrade++;
                break;
            default:
                break;
        }

        UpdateUpgrade();
    }

    public void Ability(int ability)
    {
        switch (ability)
        {
            case 1:
                if (satelite == sateliteSprites.Length)
                    break;
                satelite++;
                GameObject.FindGameObjectWithTag("Engine").GetComponent<Engine>().SpawnSatellite(satelite);
                player.Heal(player.maxLife - player.currentLife);
                break;
            case 2:
                if (shockWave == shockWaveSprites.Length)
                    break;
                player.shockwavesNb++;
                player.shockPoint -= 5;
                shockWave++;
                break;
            case 3:
                if (missileBullet == missileBulletSprites.Length)
                    break;
                missileBullet++;
                player.missileOn = true;
                break;
            case 4:
                player.laser = true;
                laser = true;
                break;
            default:
                break;
        }

        UpdateAbility();
    }

    private void UpdateAbility()
    {
        GameObject.FindGameObjectWithTag("Engine").GetComponent<AudioManager>().PlaySound(Sounds.UPGRADE);
        for (int i = 0; i < satelite; i++)
        {
            sateliteSprites[i].sprite = fillUpgrade;
        }

        for (int i = 0; i < shockWave; i++)
        {
            shockWaveSprites[i].sprite = fillUpgrade;
        }

        for (int i = 0; i < missileBullet; i++)
        {
            missileBulletSprites[i].sprite = fillUpgrade;
        }

        if (laser)
            laserSprite.sprite = fillUpgrade;
    }
}

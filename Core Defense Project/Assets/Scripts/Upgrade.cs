using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    public Player player;
    public TextMeshProUGUI infoText;

    public int costLife;
    public TextMeshProUGUI costLifeText;
    public int costFireRate;
    public TextMeshProUGUI costFireRateText;
    public int costDamage;
    public TextMeshProUGUI costDamageText;
    public int costBulletSpeed;
    public TextMeshProUGUI costBulletSpeedText;

    public int costSatelite;
    public TextMeshProUGUI costSateliteText;
    public int costShockWave;
    public TextMeshProUGUI costShockWaveText;
    public int costMissile;
    public TextMeshProUGUI costMissileText;
    public int costLaser;
    public TextMeshProUGUI costLaserText;

    public Color canBuy = Color.green;
    public Color cantBuy = Color.red;

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
        UpdateCost();
    }

    public void Update()
    {
        UpdateCanBuy();
    }

    public void UpdateCost()
    {
        costLifeText.text = costLife+"";
        costFireRateText.text = costFireRate+"";
        costDamageText.text = costDamage+"";
        costBulletSpeedText.text = costBulletSpeed+"";
        costSateliteText.text = costSatelite+"";
        costShockWaveText.text = costShockWave+"";
        costMissileText.text = costMissile+"";
        costLaserText.text = costLaser+"";
    }

    public void UpdateCanBuy()
    {
        if (GetComponent<Engine>().credit >= costLife)
        {
            costLifeText.color = Color.green;
        }
        else { costLifeText.color = Color.red; }
        if (GetComponent<Engine>().credit >= costFireRate)  
        {
            costFireRateText.color = Color.green;
        }
        else 
        { 
            costFireRateText.color = Color.red; 
        }
        if (GetComponent<Engine>().credit >= costDamage)
            
        {
            costDamageText.color = Color.green;
        }
        else 
        { 
            costDamageText.color = Color.red; 
        }
        if (GetComponent<Engine>().credit >= costBulletSpeed)
            
        {
            costBulletSpeedText.color = Color.green;
        }
        else 
        { 
            costBulletSpeedText.color = Color.red; 
        }
        if (GetComponent<Engine>().credit >= costSatelite)
            
        {
            costSateliteText.color = Color.green;
        }
        else 
        { 
            costSateliteText.color = Color.red;
        }
        if (GetComponent<Engine>().credit >= costShockWave)
            
        {
            costShockWaveText.color = Color.green;
        }
        else 
        { 
            costShockWaveText.color = Color.red; 
        }
        if (GetComponent<Engine>().credit >= costMissile)
            
        {
            costMissileText.color = Color.green;
        }
        else 
        { 
            costMissileText.color = Color.red; 
        }
        if (GetComponent<Engine>().credit >= costLaser)
            
        {
            costLaserText.color = Color.green;
        }
        else 
        { 
            costLaserText.color = Color.red; 
        }
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

    public void UpgradeStats(int stat)
    {
        switch (stat)
        {
            case 1:
                if (lifeUpgrade == lifeSprites.Length)
                    break;
                else if (CanBuy(costLife,GetComponent<Engine>().credit)) 
                {
                    player.maxLife += 2;
                    lifeUpgrade++;
                    player.Heal(player.maxLife - player.currentLife);
                    Buy(costLife);
                    costLife *= 2;
                }
                break;
            case 2:
                if (fireRateUpgrade == fireRateSprites.Length)
                    break;
                else if (CanBuy(costFireRate, GetComponent<Engine>().credit))
                {
                    Buy(costFireRate);
                    costFireRate *= 2;
                    player.fireRate = player.fireRate *0.8f;
                    fireRateUpgrade++;
                }
                break;
            case 3:
                if (damageUpgrade == damageSprites.Length)
                    break;
                else if (CanBuy(costDamage, GetComponent<Engine>().credit))
                {
                    Buy(costDamage);
                    costDamage *= 2;
                    player.bulletDamage++;
                    damageUpgrade++;
                }
                break;
            case 4:
                if (bulletSpeedUpgrade == bulletSpeedSprites.Length)
                    break;
                else if (CanBuy(costBulletSpeed, GetComponent<Engine>().credit))
                {
                    Buy(costBulletSpeed);
                    costBulletSpeed *= 2;
                    player.cannonSpeed += 100;
                    bulletSpeedUpgrade++;
                }
                break;
            default:
                break;
        }

        UpdateUpgrade();
        UpdateCost();
    }

    public bool CanBuy(int cost,int credit) 
    {
        return credit >= cost;
    }

    public void Buy(int cost  )
    {
        GetComponent<Engine>().credit -= cost;
    }

    public void Ability(int ability)
    {
        switch (ability)
        {
            case 1:
                if (satelite == sateliteSprites.Length)
                    break;
                else if (CanBuy(costSatelite, GetComponent<Engine>().credit))
                {
                    satelite++;
                    GameObject.FindGameObjectWithTag("Engine").GetComponent<Engine>().SpawnSatellite(satelite);
                    player.Heal(player.maxLife - player.currentLife);
                    Buy(costSatelite);
                }
                break;
            case 2:
                if (shockWave == shockWaveSprites.Length)
                    break;
                else if (CanBuy(costShockWave, GetComponent<Engine>().credit))
                {
                    player.shockwavesNb++;
                    player.shockPoint -= 5;
                    shockWave++;
                    Buy(costShockWave);
                    player.canShockWave=true;
                }
                break;
            case 3:
                if (missileBullet == missileBulletSprites.Length)
                    break;
                else if (CanBuy(costMissile, GetComponent<Engine>().credit))
                {
                    missileBullet++;
                    player.missileOn = true;
                    Buy(costMissile);
                }
                break;
            case 4:
                if (laser == false && CanBuy(costLaser, GetComponent<Engine>().credit))
                {
                    player.laser = true;
                    laser = true;
                    Buy(costLaser);
                }
                break;
            default:
                break;
        }

        UpdateAbility();
        UpdateCost();
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

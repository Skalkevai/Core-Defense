using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public SpawnSystem spawnSystem;

    public float maxLife;
    public float currentLife;
    public GameObject deathEffect;
    public bool isDead;
    public Image healthCircle;

    public int bulletDamage;
    public GameObject bullet;
    public GameObject missile;
    public float fireRate;
    public float sateliteDamage;
    public int sateliteRange;
    public float sateliteFireRate;

    public Rotate cannon;
    public int cannonSpeed;
    public KeyCode fireInput;
    public Transform firePoint;
    private float time;

    public bool laser;
    public LineRenderer laserLine;

    public int shockwavesNb;
    public GameObject shockWave;
    public bool canShockWave;
    public KeyCode shockWaveInput;
    public float currentShockPoint;
    public float shockPoint;
    public SpriteRenderer shock;
    public bool missileOn;

    // Start is called before the first frame update
    void Start()
    {
        spawnSystem = GameObject.FindGameObjectWithTag("Engine").GetComponent<SpawnSystem>();
        currentLife = maxLife;
        Color laserColor = Color.Lerp(GameObject.FindGameObjectWithTag("Engine").GetComponent<Engine>().playerColor, new Color (0,0,0,175),0.5f);

        laserLine.startColor = laserColor;
        laserLine.endColor = laserColor;
    }

    // Update is called once per frame
    void Update()
    {
        healthCircle.fillAmount = (currentLife / maxLife);

        time += Time.deltaTime;

        if (IsDoubleTap() && !GameObject.FindGameObjectWithTag("Engine").GetComponent<SpawnSystem>().upgradePanelOn)
        {
            if(time >= fireRate)
            {
                time = 0;
                Shoot();
            }
        }

        if (currentShockPoint >= shockPoint && canShockWave)
        {
            shock.enabled = true;
        }
        else if (currentShockPoint < shockPoint)
        {
            shock.enabled = false;
        }

        if (Input.GetKeyDown(shockWaveInput))
        {
            ShockWave();
        }

        if (laser)
        {
            laserLine.enabled = true;
            DrawLaser();
        }
        else { laserLine.enabled = false; }

        if (currentLife <= 0 && !isDead)
        {
            Die();

        }
    }
    public static bool IsDoubleTap()
    {
        bool result = false;
        float MaxTimeWait = 1;
        float VariancePosition = 1;

        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            float DeltaTime = Input.GetTouch(0).deltaTime;
            float DeltaPositionLenght = Input.GetTouch(0).deltaPosition.magnitude;

            if (DeltaTime > 0 && DeltaTime < MaxTimeWait && DeltaPositionLenght < VariancePosition)
                result = true;
        }
        return result;
    }

    public void ShockWave()
    {
        if (shockwavesNb > 0 && !isDead && currentShockPoint >= shockPoint)
        {
            currentShockPoint = 0;
            GameObject s = Instantiate(shockWave);
            Destroy(s, 2f);
        }
    }

    void Shoot()
    {
        if (isDead)
            return;

        GameObject p = null;

        if (missileOn)
        {
            p = Instantiate(missile);
            GameObject.FindGameObjectWithTag("Engine").GetComponent<AudioManager>().PlaySound(Sounds.MISSILE);
            p.GetComponent<Missile>().player = this;
        }
        else
        {
            p = Instantiate(bullet);
            GameObject.FindGameObjectWithTag("Engine").GetComponent<AudioManager>().PlaySound(Sounds.SHOOT);
            p.GetComponent<Bullet>().player = this;
        }

        p.transform.position = firePoint.position;
        p.GetComponent<Rigidbody2D>().velocity = cannon.direction.normalized*cannonSpeed*Time.deltaTime;
    
    }

    public void TakeDamage(int damage)
    {
        GameObject.FindGameObjectWithTag("Engine").GetComponent<AudioManager>().PlaySound(Sounds.PLAYERHIT);
        currentLife -= damage;
        Camera.main.GetComponent<Animator>().SetTrigger("BigShake");
    }

    public void Die()
    {
        shock.enabled = false;
        isDead = true;
        laser = false;
        GameObject e = Instantiate(deathEffect);
        GameObject.FindGameObjectWithTag("Engine").GetComponent<AudioManager>().PlaySound(Sounds.ENEMYDEAD);
        e.transform.position = Vector2.zero;
        spawnSystem.lost = true;
        spawnSystem.CallClean();
        foreach (SpriteRenderer s in GetComponentsInChildren<SpriteRenderer>())
        {
            s.enabled = false;
        }
        spawnSystem.upgradePanel.GetComponent<Animator>().SetTrigger("Close");
        spawnSystem.upgradePanel.GetComponent<Animator>().SetBool("On",false);
    }

    public void DrawLaser()
    {
        Vector3[] lineTargets = new Vector3[2];
        lineTargets[0] = firePoint.position;
        lineTargets[1] = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        laserLine.SetPositions(lineTargets);
    }

    public void Heal(float ammount) 
    {
        currentLife += ammount;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().Die();
            TakeDamage(collision.GetComponent<Enemy>().damage);
        }
        else if (collision.tag == "Credit")
        {
            Destroy(collision.gameObject);
            GameObject.FindGameObjectWithTag("Engine").GetComponent<AudioManager>().PlaySound(Sounds.COLLECT);
            GameObject.FindGameObjectWithTag("Engine").GetComponent<Engine>().credit++;
        }
    }
}

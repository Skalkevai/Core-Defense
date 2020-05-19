using System.Collections;
using System.Collections.Generic;
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
    public float fireRate;
    public float sateliteDamage;
    public int sateliteRange;
    public float sateliteFireRate;

    public Rotate cannon;
    public int cannonSpeed;
    public KeyCode fireInput;
    public Transform firePoint;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        spawnSystem = GameObject.FindGameObjectWithTag("Engine").GetComponent<SpawnSystem>();
        currentLife = maxLife;   
    }

    // Update is called once per frame
    void Update()
    {
        healthCircle.fillAmount = (currentLife / maxLife);

        time += Time.deltaTime;

        if (Input.GetKeyDown(fireInput))
        {
            if(time >= fireRate)
            {
                time = 0;
                Shoot();
            }
        }



        if (currentLife <= 0 && !isDead)
        {
            Die();
        }
    }

    void Shoot()
    {
        GameObject b = Instantiate(bullet);
        b.GetComponent<Bullet>().player = this;
        b.transform.position = firePoint.position;
        b.GetComponent<Rigidbody2D>().velocity = cannon.direction.normalized*cannonSpeed;
    
    }

    public void TakeDamage(int damage)
    {
        currentLife -= damage;
        Camera.main.GetComponent<Animator>().SetTrigger("BigShake");
    }

    public void Die()
    {
        isDead = true;
        GameObject e = Instantiate(deathEffect);
        e.transform.position = Vector2.zero;
        spawnSystem.lost = true;
        spawnSystem.CallClean();
        foreach (SpriteRenderer s in GetComponentsInChildren<SpriteRenderer>())
        {
            s.enabled = false;
        }
        
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
            GameObject.FindGameObjectWithTag("Engine").GetComponent<Engine>().credit++;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [HideInInspector]
    public Player player;
    public GameObject bulletExplosion;
    [HideInInspector]
    public Transform enemies;
    public int detectRange;
    public int rotateSpeed;
    
    public Transform target;
    public Transform tempTarget;
    private Rigidbody2D rb;
    public Transform effects;
    public void Start()
    {
        GetComponent<SpriteRenderer>().color = GameObject.FindGameObjectWithTag("Engine").GetComponent<Engine>().playerColor;
        GetComponentInChildren<ParticleSystem>().startColor = GameObject.FindGameObjectWithTag("Engine").GetComponent<Engine>().playerColor; ;
        enemies = GameObject.FindGameObjectWithTag("Enemies").transform;
        rb = GetComponent<Rigidbody2D>();
        tempTarget = GameObject.FindGameObjectWithTag("Temp").transform;
        effects = GameObject.FindGameObjectWithTag("Effects").transform;
    }

    public void Update()
    {

            foreach (Transform e in enemies.GetComponentsInChildren<Transform>())
            {
                if (e.tag == "Enemy" && Vector2.Distance(transform.position, e.position) <= detectRange)
                {
                    target = e;
                }
            }
    }

    void FixedUpdate()
    {
        if (target == null)
        {
            tempTarget.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            tempTarget.position = tempTarget.position * 10;
            target = tempTarget;
            Vector2 direction = (Vector2)target.position - rb.position;
            direction.Normalize();

            float rotateAround = Vector3.Cross(direction, transform.up).z;
            rb.angularVelocity = -rotateAround * rotateSpeed * 1000;
            rb.velocity = direction * player.cannonSpeed * Time.deltaTime;
        }

        else if (target != null)
        {
            Vector2 direction = (Vector2)target.position - rb.position;
            direction.Normalize();

            float rotateAround = Vector3.Cross(direction, transform.up).z;
            rb.angularVelocity = -rotateAround * rotateSpeed*1000;
            rb.velocity = direction * player.cannonSpeed * Time.deltaTime;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            GameObject.FindGameObjectWithTag("Engine").GetComponent<Engine>().AddScore(10);
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().currentShockPoint += 1f;
            collision.GetComponent<Enemy>().TakeDamage(player.bulletDamage*2);

            GetComponentInChildren<ParticleSystem>().Stop();
            GetComponentInChildren<ParticleSystem>().gameObject.transform.parent = effects.transform;
            Destroy(effects.GetComponentInChildren<ParticleSystem>().gameObject,6f);

            Destroy(gameObject);
            GameObject e = Instantiate(bulletExplosion);
            e.GetComponent<ParticleSystem>().startColor = GameObject.FindGameObjectWithTag("Engine").GetComponent<Engine>().playerColor;
            e.transform.position = this.transform.position;
        }
    }
}

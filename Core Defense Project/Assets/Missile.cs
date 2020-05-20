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
    [HideInInspector]
    public Transform target;
    private Rigidbody2D rb;

    public void Start()
    {
        GetComponent<SpriteRenderer>().color = GameObject.FindGameObjectWithTag("Engine").GetComponent<Engine>().playerColor;
        enemies = GameObject.FindGameObjectWithTag("Enemies").transform;
        rb = GetComponent<Rigidbody2D>();
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
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
            direction.Normalize();

            float rotateAround = Vector3.Cross(direction, transform.up).z;
            rb.angularVelocity = -rotateAround * rotateSpeed;
            rb.velocity = transform.up * player.cannonSpeed * Time.deltaTime;
        }
        else
        {
            Vector2 direction = (Vector2)target.position - rb.position;
            direction.Normalize();
            float rotateAround = Vector3.Cross(direction, transform.up).z;
            rb.angularVelocity = -rotateAround * rotateSpeed;
            rb.velocity = transform.up * player.cannonSpeed * Time.deltaTime;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            GameObject.FindGameObjectWithTag("Engine").GetComponent<Engine>().AddScore(10);
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().currentShockPoint += 1f;
            collision.GetComponent<Enemy>().TakeDamage(player.bulletDamage*2);
            Destroy(gameObject);
            GameObject e = Instantiate(bulletExplosion);
            e.GetComponent<ParticleSystem>().startColor = GameObject.FindGameObjectWithTag("Engine").GetComponent<Engine>().playerColor;
            e.transform.position = this.transform.position;
        }
    }
}

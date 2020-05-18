using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector]
    public Player player;
    public GameObject bulletExplosion;

    public void Start()
    {
        GetComponent<SpriteRenderer>().color = GameObject.FindGameObjectWithTag("Engine").GetComponent<Engine>().playerColor;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            GameObject.FindGameObjectWithTag("Engine").GetComponent<Engine>().AddScore(10);
            collision.GetComponent<Enemy>().TakeDamage(player.bulletDamage);
            Destroy(gameObject);
            GameObject e = Instantiate(bulletExplosion);
            e.GetComponent<ParticleSystem>().startColor = GameObject.FindGameObjectWithTag("Engine").GetComponent<Engine>().playerColor;
            e.transform.position = this.transform.position;
        }
    }
}

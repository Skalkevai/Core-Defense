using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MiniBullet : MonoBehaviour
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
            GameObject.FindGameObjectWithTag("Engine").GetComponent<Engine>().AddScore(5);
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().currentShockPoint += .5f;
            collision.GetComponent<Enemy>().TakeDamage(player.sateliteDamage);
            Destroy(gameObject);
            GameObject e = Instantiate(bulletExplosion);
            e.GetComponent<ParticleSystem>().startColor = GameObject.FindGameObjectWithTag("Engine").GetComponent<Engine>().playerColor;
            e.transform.position = this.transform.position;
        }
    }
}

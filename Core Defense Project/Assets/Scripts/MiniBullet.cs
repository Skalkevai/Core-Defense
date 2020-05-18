using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MiniBullet : MonoBehaviour
{
    [HideInInspector]
    public Player player;
    public GameObject bulletExplosion;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            GameObject.FindGameObjectWithTag("Engine").GetComponent<Engine>().AddScore(5);
            collision.GetComponent<Enemy>().TakeDamage(player.sateliteDamage);
            Destroy(gameObject);
            GameObject e = Instantiate(bulletExplosion);
            e.transform.position = this.transform.position;
        }
    }
}

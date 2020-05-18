using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector]
    public Player player;
    public GameObject bulletExplosion;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().TakeDamage(player.bulletDamage);
            Destroy(gameObject);
            GameObject e = Instantiate(bulletExplosion);
            e.transform.position = this.transform.position;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satellite : MonoBehaviour
{
    private Vector2 direction;
    public Player player;

    public Transform target;
    public Transform enemies;

    private int range;
    public GameObject cannon;
    public GameObject bullet;
    public Transform firePoint;
    public int cannonSpeed;
    float fireRate;
    float time = 0;
    private void Start()
    {
        enemies = GameObject.FindGameObjectWithTag("Enemies").transform;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        range = player.sateliteRange;
        fireRate = player.sateliteFireRate;

        foreach (Transform enemy in enemies.GetComponentsInChildren<Transform>())
        {
            if (enemy.tag == "Enemy" && Vector2.Distance(transform.position, enemy.position) <= range)
            {
                target = enemy;
            }
        }

        if (target != null && Vector2.Distance(target.position, transform.position) > range)
        {
            target = null;
        }

        time += Time.deltaTime;

        if (target != null)
        {
            FaceEnemy();
            if (time >= fireRate)
            {
                time = 0;
                Shoot();
            }
        }

    }

    void FaceEnemy()
    {
        direction = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y);
        cannon.transform.up = direction;
    }

    public void Shoot()
    {
        GameObject b = Instantiate(bullet);
        b.GetComponent<MiniBullet>().player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        b.transform.position = firePoint.position;
        b.GetComponent<Rigidbody2D>().velocity = direction.normalized * cannonSpeed;

    }
    

}

using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform target;

    public int speed;
    public int maxLife;
    [HideInInspector]
    public float currentLife;
    public int damage;
    public GameObject deadEffect;

    public GameObject credit;
    public int creditChance;
    public Transform credits;

    // Start is called before the first frame update
    void Start()
    {
        credits = GameObject.FindGameObjectWithTag("Credits").transform;
        GetComponent<SpriteRenderer>().color = GameObject.FindGameObjectWithTag("Engine").GetComponent<Engine>().enemyColor;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        currentLife = maxLife;
    }

    private void Update()
    {
        if (currentLife <= 0)
            Die();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(target.position);
        transform.Rotate(new Vector3(0,-90, 0), Space.Self);
        if(!GameObject.FindGameObjectWithTag("Engine").GetComponent<SpawnSystem>().lost)
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);     
    }

    public void TakeDamage(float damage)
    {
        currentLife -= damage;
    }

    public void Die()
    {
        GameObject.FindGameObjectWithTag("Engine").GetComponent<Engine>().AddScore(50);

        GameObject de = Instantiate(deadEffect);
        de.GetComponent<ParticleSystem>().startColor = GameObject.FindGameObjectWithTag("Engine").GetComponent<Engine>().enemyColor;
        de.transform.position = this.transform.position;

        GameObject.FindGameObjectWithTag("Engine").GetComponent<SpawnSystem>().nbEnemy--;
        Camera.main.GetComponent<Animator>().SetTrigger("SmallShake");

        int r= Random.Range(0,100);
        if (r <= creditChance)
        {
            GameObject c = Instantiate(credit,credits);
            c.transform.position = transform.position;
        }

        Destroy(gameObject);
    }
}

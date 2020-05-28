using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.Rendering;

public class SpawnSystem : MonoBehaviour
{
    int startMaxNbEnemy = 5;
    int maxNbEnemy;
    int currentWave;

    public GameObject upgradePanel;
    public bool upgradePanelOn;

    public GameObject waveText;

    public GameObject enemy;
    public GameObject[] enemyPool;
    public int nbEnemy;
    public Transform enemies;

    public bool lost;

    // Start is called before the first frame update
    void Start()
    {
        currentWave = 1;
        StartWave(currentWave);
    }

    // Update is called once per frame
    void Update()
    {
        if (nbEnemy == 0)
            {
                CollectCredit();
            }
    }

    public void NextWave()
    { 
        upgradePanelOn = false;
        upgradePanel.GetComponent<Animator>().SetBool("On",false);
        upgradePanel.GetComponent<Animator>().SetTrigger("Down");


        StartWave(currentWave + 1);
    }
    
    public void CollectCredit()
    {
        Item[] credits = GameObject.FindObjectsOfType<Item>();
        foreach (Item item in credits)
        {
            item.Collect();
        }
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isDead)
        {
            upgradePanelOn = true;
            upgradePanel.GetComponent<Animator>().SetBool("On", true);
            upgradePanel.GetComponent<Animator>().SetTrigger("Up");
        }
    }
    
    public void StartWave(int waveNb)
    {
        GameObject w = Instantiate(waveText,GameObject.FindGameObjectWithTag("Canvas").transform);
        w.GetComponent<TextMeshProUGUI>().text = "Waves : " + waveNb;
        Destroy(w,2f);

        //Wave
        currentWave = waveNb;
        maxNbEnemy = startMaxNbEnemy + (waveNb/2);

        //Spawn Area
        for (int i = 0; i < maxNbEnemy; i++)
        {
            int x = UnityEngine.Random.Range(-15, 15);
            while (x < 10 && x > -10)
            {
                x = UnityEngine.Random.Range(-15, 15);
            }
            int y = UnityEngine.Random.Range(-10, 10);
            while (x < 5 && x > -5)
            {
                x = UnityEngine.Random.Range(-10, 10);
            }


            //Spawn Enemy
            GameObject e = Instantiate(enemy,enemies);
            nbEnemy++;
            e.transform.position = new Vector2(x, y);
        }
    }

    public IEnumerator ClearScreen()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject e in enemies)
        {
            if(e!=null)
                e.GetComponent<Enemy>().Die();
            yield return new WaitForSeconds(0.50f);
        }

        GetComponent<Engine>().Lost(currentWave);
    }

    public void CallClean()
    {
        StartCoroutine(ClearScreen());
    }
}

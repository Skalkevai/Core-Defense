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
    float timer;
    float currentTimer;

    public TextMeshProUGUI waveText;
    public TextMeshProUGUI timerText;

    public GameObject enemy;
    public int nbEnemy;

    public bool lost;

    // Start is called before the first frame update
    void Start()
    {
        timer = 20;
        currentTimer = timer;
        StartWave(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (!lost)
        {

            //UI Timer
            float minutes = Mathf.Floor(currentTimer / 60);
            float seconds = Mathf.RoundToInt(currentTimer % 60);
            timerText.text = "0" + minutes + ":" + seconds;
            if (seconds < 10)
            {
                timerText.text = "0" + minutes + ":0" + seconds;
            }

            //UI Waves
            waveText.text = "Waves : " + currentWave;

            //Timer 
            currentTimer -= Time.deltaTime;

            if (currentTimer <= 0)
            {
                StartWave(currentWave + 1);
                int timerExtra = (int)(currentTimer / 5f);
                timer += timerExtra;
                currentTimer = timer;
            }

            //Skip Timer
            if (nbEnemy == 0)
            {
                currentTimer = 0;
            }
        }
    }

    public void StartWave(int waveNb)
    {
        //Wave
        currentWave = waveNb;
        maxNbEnemy = startMaxNbEnemy + (1 * waveNb);

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
            GameObject e = Instantiate(enemy);
            nbEnemy++;
            e.transform.position = new Vector2(x, y);
        }
    }

    public IEnumerator ClearScreen()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject e in enemies)
        {
            e.GetComponent<Enemy>().Die();
            yield return new WaitForSeconds(0.50f);
        }

        GetComponent<Engine>().Lost();
    }

    public void CallClean()
    {
        StartCoroutine(ClearScreen());
    }
}

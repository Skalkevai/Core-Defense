using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Engine : MonoBehaviour
{
    public int credit;

    public Transform orbit1;
    public Transform orbit2;
    public Transform orbit3;
    public GameObject satellite;

    public TextMeshProUGUI lostText;
    public TextMeshProUGUI highScoresText;
    public int highScores;

    public Color playerColor;
    public SpriteRenderer[] playersSprites;
    public Image lifeRadial;

    public Color enemyColor;

    public void Start()
    {
        foreach (SpriteRenderer s in playersSprites)
        {
            s.color = playerColor;
        }
        lifeRadial.color = playerColor;


    }

    public void Lost(int nbWave)
    {
        lostText.text = "You Survived " + (nbWave-1) + " Waves";
        highScoresText.text = "HighScores : "+ highScores;
        GetComponent<Animator>().SetTrigger("Lost");   
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            SpawnSatellite(orbit1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SpawnSatellite(orbit2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SpawnSatellite(orbit3);
        }

    }

    public void AddScore(int scores)
    {
        highScores += scores;
    }

    public void SpawnSatellite(Transform orbit)
    {
        GameObject s = Instantiate(satellite,orbit);
    }
}

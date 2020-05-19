using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;

public class Engine : MonoBehaviour
{
    public int credit;
    public TextMeshProUGUI creditNumberText;

    public Transform orbit1;
    public Transform orbit2;
    public Transform orbit3;
    public GameObject satellite;

    public TextMeshProUGUI lostText;
    public TextMeshProUGUI highScoresText;
    public int highScores;

    public Color playerColor;
    public Color colorDarker;
    private Color playerColorDarker;
    public SpriteRenderer[] playersSprites;
    public Image lifeRadial;
    public GameObject centralLight;

    public Color enemyColor;
    public Color itemColor;

    public void Start()
    {
        //SetColor
        foreach (SpriteRenderer s in playersSprites)
        {
            s.color = playerColor;
        }
        lifeRadial.color = playerColor;

        playerColorDarker = Color.Lerp(playerColor, colorDarker, 0.5f);
        centralLight.GetComponent<Light2D>().color = playerColorDarker;

    }

    public void Lost(int nbWave)
    {
        lostText.text = "You Survived " + (nbWave-1) + " Waves";
        highScoresText.text = "HighScores : "+ highScores;
        GetComponent<Animator>().SetTrigger("Lost");   
    }

    public void Update()
    {
        creditNumberText.text = ""+credit;
    }

    public void AddScore(int scores)
    {
        highScores += scores;
    }

    public void SpawnSatellite(int satelite)
    {
        
        switch (satelite)
        {
            case 1:
                GameObject s1 = Instantiate(satellite, orbit1);
                break;
            case 2:
                GameObject s2 = Instantiate(satellite, orbit2);
                break;
            case 3:
                GameObject s3 = Instantiate(satellite, orbit3);
                break;
        }
    }
}

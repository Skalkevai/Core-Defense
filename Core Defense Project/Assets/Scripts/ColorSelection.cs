using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSelection : MonoBehaviour
{
    public Color player;
    public Color enemy;

    public GameObject selectionPlayer;
    public GameObject selectionEnemy;

    public Color blue;
    public GameObject blueObjectPlayer;
    public GameObject blueObjectEnemy;
    public Color green;
    public GameObject greenObjectPlayer;
    public GameObject greenObjectEnemy;
    public Color orange;
    public GameObject orangeObjectPlayer;
    public GameObject orangeObjectEnemy;
    public Color yellow;
    public GameObject yellowObjectPlayer;
    public GameObject yellowObjectEnemy;
    public Color purple;
    public GameObject purpleObjectPlayer;
    public GameObject purpleObjectEnemy;
    public Color pink;
    public GameObject pinkObjectPlayer;
    public GameObject pinkObjectEnemy;
    public Color white;
    public GameObject whiteObjectPlayer;
    public GameObject whiteObjectEnemy;
    public Color red;
    public GameObject redObjectPlayer;
    public GameObject redObjectEnemy;


    public void Start()
    {
        ChangePlayerColor(PlayerPrefs.GetString("PlayerColor"));
        ChangeEnemyColor(PlayerPrefs.GetString("EnemyColor"));
    }

    public void ChangePlayerColor(string colorName)
    {
        switch (colorName)
        {
            case "blue":
                player = blue;
                selectionPlayer.transform.position = new Vector3(blueObjectPlayer.transform.position.x, blueObjectPlayer.transform.position.y, 0);
                PlayerPrefs.SetString("PlayerColor", "blue");
                break;
            case "green":
                player = green;
                selectionPlayer.transform.position = new Vector3(greenObjectPlayer.transform.position.x, greenObjectPlayer.transform.position.y, 0);
                PlayerPrefs.SetString("PlayerColor", "green");
                break;
            case "orange":
                player = orange;
                selectionPlayer.transform.position = new Vector3(orangeObjectPlayer.transform.position.x, orangeObjectPlayer.transform.position.y, 0);
                PlayerPrefs.SetString("PlayerColor", "orange");
                break;
            case "yellow":
                player = yellow;
                selectionPlayer.transform.position = new Vector3(yellowObjectPlayer.transform.position.x, yellowObjectPlayer.transform.position.y, 0);
                PlayerPrefs.SetString("PlayerColor", "yellow");
                break;
            case "purple":
                player = purple;
                selectionPlayer.transform.position = new Vector3(purpleObjectPlayer.transform.position.x, purpleObjectPlayer.transform.position.y, 0);
                PlayerPrefs.SetString("PlayerColor", "purple");
                break;
            case "pink":
                player = pink;
                selectionPlayer.transform.position = new Vector3(pinkObjectPlayer.transform.position.x, pinkObjectPlayer.transform.position.y, 0);
                PlayerPrefs.SetString("PlayerColor", "pink");
                break;
            case "white":
                player = white;
                selectionPlayer.transform.position = new Vector3(whiteObjectPlayer.transform.position.x, whiteObjectPlayer.transform.position.y, 0);
                PlayerPrefs.SetString("PlayerColor", "white");
                break;
            case "red":
                player = red;
                selectionPlayer.transform.position = new Vector3(redObjectPlayer.transform.position.x, redObjectPlayer.transform.position.y, 0);
                PlayerPrefs.SetString("PlayerColor", "red");
                break;
            default:
                break;
        }
        PlayerPrefs.Save();
    }

    public void ChangeEnemyColor(string colorName)
    {
        switch (colorName)
        {
            case "blue":
                selectionEnemy.transform.position = new Vector3(blueObjectEnemy.transform.position.x, blueObjectEnemy.transform.position.y, 0);
                enemy = blue;
                PlayerPrefs.SetString("EnemyColor", "blue");
                break;
            case "green":
                enemy = green;
                selectionEnemy.transform.position = new Vector3(greenObjectEnemy.transform.position.x, greenObjectEnemy.transform.position.y, 0);
                PlayerPrefs.SetString("EnemyColor", "green");
                break;
            case "orange":
                enemy = orange;
                selectionEnemy.transform.position = new Vector3(orangeObjectEnemy.transform.position.x, orangeObjectEnemy.transform.position.y, 0);
                PlayerPrefs.SetString("EnemyColor", "orange");
                break;
            case "yellow":
                enemy = yellow;
                selectionEnemy.transform.position = new Vector3(yellowObjectEnemy.transform.position.x, yellowObjectEnemy.transform.position.y, 0);
                PlayerPrefs.SetString("EnemyColor", "yellow");
                break;
            case "purple":
                enemy = purple;
                selectionEnemy.transform.position = new Vector3(purpleObjectEnemy.transform.position.x, purpleObjectEnemy.transform.position.y, 0);
                PlayerPrefs.SetString("EnemyColor", "purple");
                break;
            case "pink":
                enemy = pink;
                selectionEnemy.transform.position = new Vector3(pinkObjectEnemy.transform.position.x, pinkObjectEnemy.transform.position.y, 0);
                PlayerPrefs.SetString("EnemyColor", "pink");
                break;
            case "white":
                enemy = white;
                selectionEnemy.transform.position = new Vector3(whiteObjectEnemy.transform.position.x, whiteObjectEnemy.transform.position.y, 0);
                PlayerPrefs.SetString("EnemyColor", "white");
                break;
            case "red":
                enemy = red;
                selectionEnemy.transform.position = new Vector3(redObjectEnemy.transform.position.x, redObjectEnemy.transform.position.y, 0);
                PlayerPrefs.SetString("EnemyColor", "red");
                break;

            default:
                break;
        }
        PlayerPrefs.Save();
    }
}

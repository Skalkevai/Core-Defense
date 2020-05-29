using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColorChanging : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject enemy1;
    public GameObject enemy2;

    public ColorSelection colorSelection;

    public Color playerColor;
    public Color enemyColor;

    void Start()
    {
        if (PlayerPrefs.GetString("PlayerColorEngine") == "")
        {
            PlayerPrefs.SetString("PlayerColorEngine", ColorToHex(playerColor));

        }
        if (PlayerPrefs.GetString("EnemyColorEngine") == "")
        {
            PlayerPrefs.SetString("EnemyColorEngine", ColorToHex(enemyColor));
        }

        if (SceneManager.GetActiveScene().name != "Custom")
        {
            playerColor = HexToColor(PlayerPrefs.GetString("PlayerColorEngine"));
            enemyColor = HexToColor(PlayerPrefs.GetString("EnemyColorEngine"));
        }

        if (SceneManager.GetActiveScene().name == "Custom")
        {
            playerColor = HexToColor(PlayerPrefs.GetString("PlayerColorEngine"));
            enemyColor = HexToColor(PlayerPrefs.GetString("EnemyColorEngine"));
            colorSelection.player = playerColor;
            colorSelection.enemy = enemyColor;
        }
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Custom")
        {
            playerColor = colorSelection.player;
            enemyColor = colorSelection.enemy;
        }

        player1.GetComponent<SpriteRenderer>().color = playerColor;
        player2.GetComponent<SpriteRenderer>().color = playerColor;
        enemy1.GetComponent<SpriteRenderer>().color = enemyColor;
        enemy2.GetComponent<SpriteRenderer>().color = enemyColor;
    }

    public void SaveColor()
    {
        PlayerPrefs.SetString("PlayerColorEngine", ColorToHex(playerColor));
        PlayerPrefs.SetString("EnemyColorEngine", ColorToHex(enemyColor));
    }
    string ColorToHex(Color32 color)
    {
        string hex = color.r.ToString("X2") + color.g.ToString("X2") + color.b.ToString("X2");
        return hex;
    }

    Color HexToColor(string hex)
    {
        byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
        byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
        byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
        return new Color32(r, g, b, 255);
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public enum ButtonUpgrade{LIFE,FIRERATE,DAMAGE,BULLETSPEED,SATELITE,SHOCKWAVE,MISSILE,LASER}
public class Info : MonoBehaviour
{
    public Upgrade upgrade;
    public string description;

    public int detectRange;

    public void Start()
    {
        
    }

    public void Update()
    {
        if (Vector2.Distance(transform.position, (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition)) <= detectRange)
        {
            upgrade.infoText.text =description;
        }
        else 
        { 
        
        }
    }

}

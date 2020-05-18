using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour
{
    public int credit;

    public Transform orbit1;
    public Transform orbit2;
    public Transform orbit3;

    public GameObject satellite;

    

    public void Lost(int nbWave)
    {
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

    public void SpawnSatellite(Transform orbit)
    {
        GameObject s = Instantiate(satellite,orbit);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public float collectSpeed;
    public bool collecting;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().color = GameObject.FindGameObjectWithTag("Engine").GetComponent<Engine>().itemColor;
        GetComponent<ParticleSystem>().startColor = GameObject.FindGameObjectWithTag("Engine").GetComponent<Engine>().itemColor;
    }

    private void Update()
    {
        if (collecting)
        {
            transform.position = Vector2.MoveTowards(transform.position, Vector2.zero, collectSpeed * Time.deltaTime);
        }
    }

    public void Collect()
    {
        collecting = true;
    }

}

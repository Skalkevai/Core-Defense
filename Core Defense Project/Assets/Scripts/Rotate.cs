using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Rotate : MonoBehaviour
{
    public Vector2 direction;
    public Vector2 touchPosition;


    // Update is called once per frame
    void Update()
    {
       
       FaceMouse();
    }

    void FaceMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);


        direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

        transform.up = direction;
    }
}


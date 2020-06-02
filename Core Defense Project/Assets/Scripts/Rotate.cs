using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Rotate : MonoBehaviour
{
    public Vector2 direction;
    public Vector2 touchPosition;

    public bool onMobile;

    private void Start()
    {
        if(SceneManager.GetActiveScene().name == "Game")
            onMobile  = GameObject.FindGameObjectWithTag("Engine").GetComponent<Engine>().onMobile;
    }

    // Update is called once per frame
    void Update()
    {
        if (onMobile)
        {

            if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                FaceTouch();
            }
        }
        else
        {
            FaceMouse();
        }
    }

    void FaceMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        

        direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

        transform.up = direction;
    }

    void FaceTouch()
    {
        touchPosition = Input.GetTouch(1).position;
        direction = new Vector2(touchPosition.x - transform.position.x, touchPosition.y - transform.position.y);
        transform.up = direction;
    }
}

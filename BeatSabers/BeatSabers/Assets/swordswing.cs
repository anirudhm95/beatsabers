using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordswing : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0)) //Swing saber when click is down
        {
            this.transform.Rotate(90, 0, 0);
        }
        else if (Input.GetMouseButtonUp(0)) //Release saber when click is up
        {
            this.transform.Rotate(-90, 0, 0);
        }


        Vector3 temp = Input.mousePosition;
        temp.z = 2f; // Set this to be the distance you want the object to be placed in front of the camera.
        this.transform.position = Camera.main.ScreenToWorldPoint(temp); //Update position to mouse position
    }
}

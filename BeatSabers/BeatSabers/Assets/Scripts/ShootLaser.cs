using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLaser : MonoBehaviour {

    private LineRenderer laser;
    private Vector3 laserPosition;
    private float speed = 8.0f;
    private bool hasFinishedSpawning;


    // Use this for initialization
    void Start () {
        laser = GetComponent<LineRenderer>();
        laserPosition = new Vector3(0,0,0);
        hasFinishedSpawning = false;
    }

    // Update is called once per frame
    void Update() {
        if (hasFinishedSpawning)
        {
            laserPosition = new Vector3(0, 0, laserPosition.z + (speed * Time.deltaTime));
            laser.SetPosition(0, laserPosition);
            RaycastHit hit;

            if (Physics.Raycast(laserPosition, new Vector3(0, 0, 0), out hit))
            {
                if (hit.collider)
                    laser.SetPosition(1, hit.point);
            }
            else laser.SetPosition(1, new Vector3(0, 0, laserPosition.z + 5));
        }
    }

    public void SetHasFinishedSpawning(bool temp) {
        hasFinishedSpawning = temp;
    }
}

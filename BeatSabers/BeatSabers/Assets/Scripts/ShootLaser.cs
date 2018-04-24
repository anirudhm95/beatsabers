using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLaser : MonoBehaviour {

    private LineRenderer laser;
    private CapsuleCollider laserHitbox;
    private Vector3 laserPosition;
    private float speed = 8.0f;
    private bool hasFinishedSpawning;
    private float counter;
    private float lerpAmount;

    // Use this for initialization
    void Start () {
        laser = GetComponent<LineRenderer>();
        laserPosition = new Vector3(0,0,0);
        hasFinishedSpawning = false;
        counter = 0.0f;
        laserHitbox = transform.Find("LaserHitbox").gameObject.GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update() {

        if (hasFinishedSpawning && counter < 5)
        {
            counter += 0.1f;
            float x = Mathf.Lerp(0, 5, counter);
            laser.SetPosition(0, laserPosition);
            laser.SetPosition(1, new Vector3(0, 0, laserPosition.z + counter));
            if (counter >= 5)
                GetComponent<RobotFadeIn>().BeginFadeout();
        }
        else if (counter >= 5)
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

            laserHitbox.transform.Translate(new Vector3((speed * Time.deltaTime),0,0));
        }
    }

    public void SetHasFinishedSpawning(bool temp) {
        hasFinishedSpawning = temp;
    }
}

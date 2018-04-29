using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaberCollisionRight : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerRight")
        {
            Destroy(gameObject);
            SteamVR_Controller.Input(2).TriggerHapticPulse(3000);
        }
        Debug.Log(message: other.tag);
    }
}

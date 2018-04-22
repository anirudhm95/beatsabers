using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaberCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerLeft")
        {
            Destroy(gameObject);
            SteamVR_Controller.Input(1).TriggerHapticPulse(3999);
        }
        Debug.Log(message: other.tag);
    }
}

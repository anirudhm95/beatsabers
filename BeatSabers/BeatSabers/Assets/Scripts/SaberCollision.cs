using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaberCollision : MonoBehaviour {
    SteamVR_Controller.Device device { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
    SteamVR_TrackedObject trackedObj;
    GameObject tracked;
	// Use this for initialization
	void Start () {
        tracked = GameObject.Find("Controller (left)");
		trackedObj = tracked.GetComponent<SteamVR_TrackedObject>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (device.velocity.sqrMagnitude > 1)
        {
            if (other.tag == "PlayerLeft")
            {

                Destroy(gameObject);
                SteamVR_Controller.Input(1).TriggerHapticPulse(3999);

            }
        }
        Debug.Log(message: other.tag);
    }
}

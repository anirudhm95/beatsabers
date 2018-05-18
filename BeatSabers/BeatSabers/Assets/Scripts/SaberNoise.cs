using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaberNoise : MonoBehaviour {
    SteamVR_Controller.Device device { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
    SteamVR_TrackedObject trackedObj;
    GameObject tracked;
    // Use this for initialization
    void Start () {
        tracked = GameObject.Find("Controller (left)");
        trackedObj = tracked.GetComponent<SteamVR_TrackedObject>();
        FindObjectOfType<AudioManager>().Play("LSGlow");
    }
	
	// Update is called once per frame
	void Update () {
        if (device.velocity.sqrMagnitude > 1)
        {
            FindObjectOfType<AudioManager>().Play("Stroke");
        }
    }
}

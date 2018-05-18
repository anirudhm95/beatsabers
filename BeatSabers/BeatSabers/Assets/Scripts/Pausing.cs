using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausing : MonoBehaviour {

    private GameObject pause;
    bool isPaused;

    SteamVR_Controller.Device device { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
    Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
    Valve.VR.EVRButtonId touchPad = Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad;
    SteamVR_TrackedObject trackedObj;
    GameObject tracked;
    float StartPressDown;
    public AudioSource aSource;
    public GameObject AudioManager;
    // Use this for initialization
    void Start () {
        tracked = GameObject.Find("Controller (left)");
        trackedObj = tracked.GetComponent<SteamVR_TrackedObject>();
        isPaused = false;
        AudioManager = GameObject.Find("AudioManager");
    }
	
	// Update is called once per frame
	void Update () {
        if (device.GetPressDown(touchPad))
        {
            Debug.Log(isPaused);
            if (!isPaused)
                Pause();
            else
                Unpause();
        }
        if (device.GetPress(touchPad) && device.GetPress(triggerButton) && isPaused) {
            Time.timeScale = 1f;
            isPaused = false;
            SceneManager.LoadScene("NewMenu");
        }

	}

    void Pause ()
    {
        Time.timeScale = 0f;
        isPaused = true;
        AudioManager.GetComponent<AudioManager>().Pause();
    }

    void Unpause()
    {
        Time.timeScale = 1f;
        isPaused = false;
        AudioManager.GetComponent<AudioManager>().UnPause();
    }
}

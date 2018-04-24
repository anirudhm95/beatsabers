using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaberCollisionRight : MonoBehaviour
{
    public static GameObject DifficultyManager;
    // Use this for initialization
    void Start()
    {
        DifficultyManager = GameObject.Find("Spawner");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerRight")
        {
            DifficultyManager.GetComponent<DifficultyManager>().incrementNotesHit();
            Destroy(gameObject);
            SteamVR_Controller.Input(2).TriggerHapticPulse(3000);
        }
        //Debug.Log(message: other.tag);
    }
}

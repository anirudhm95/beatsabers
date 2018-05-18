using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaberCollisionRight : MonoBehaviour
{
    SteamVR_Controller.Device device { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
    SteamVR_TrackedObject trackedObj;
    GameObject tracked;
    public float distance = 0.0f;
    public int score = 0;
    private int controllerIndex;
    public static GameObject DifficultyManager;
    private bool inReactionArea, collided;
    // Use this for initialization
    void Start()
    {
        tracked = GameObject.Find("Controller (right)");
        trackedObj = tracked.GetComponent<SteamVR_TrackedObject>();
        controllerIndex = tracked.GetComponent<SteamVR_TrackedObject>().GetDeviceIndex();
        DifficultyManager = GameObject.Find("Spawner");
        inReactionArea = false;
        collided = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (inReactionArea && collided)
        {
            if (device.velocity.sqrMagnitude > 1)
            {
                string hitbox = "Reaction";
                GameObject hitBox = GameObject.FindGameObjectWithTag(hitbox);
                distance = Mathf.Abs(transform.position.z - hitBox.transform.position.z);

                SteamVR_Controller.Input(controllerIndex).TriggerHapticPulse(3999);

                if (distance < 0.2)
                {
                    score = 5;
                }
                else if (distance < 0.5)
                {
                    score = 2;
                }
                else
                {
                    score = 1;
                }

                FindObjectOfType<AudioManager>().Play("OrbHit");

                Debug.Log("Score: " + score);
                DifficultyManager.GetComponent<DifficultyManager>().IncrementNotesHit(score);
                SteamVR_Controller.Input(4).TriggerHapticPulse(3999);
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerRight")
        {
            collided = true;
        }
            if (other.tag == "Respawn")
        {
            GetComponent<ParticleSystem>().startColor = new Color(255, 255, 255, 255);
        }

        if (other.tag == "Reaction")
        {
            GetComponent<ParticleSystem>().startColor = new Color(0, 0, 0, 255);
            inReactionArea = true;
        }
        //if (device.velocity.sqrMagnitude > 50)
        //{
        //    if (other.tag == "PlayerRight")
        //    {
        //        string hitbox = "Reaction";
        //        GameObject hitBox = GameObject.FindGameObjectWithTag(hitbox);
        //        distance = Mathf.Abs(transform.position.z - hitBox.transform.position.z);


        //        if (distance < 0.2)
        //        {
        //            score = 5;
        //        }
        //        else if (distance < 0.5)
        //        {
        //            score = 2;
        //        }
        //        else
        //        {
        //            score = 1;
        //        }

        //        Debug.Log("Score: " + score);
        //        DifficultyManager.GetComponent<DifficultyManager>().IncrementNotesHit(score);
        //        SteamVR_Controller.Input(4).TriggerHapticPulse(3999);
        //        Destroy(gameObject);

        //    }
        //}

        //Debug.Log(message: other.tag);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Reaction")
        {
            DifficultyManager.GetComponent<DifficultyManager>().BreakStreak();
            inReactionArea = false;
        }
        else if (other.tag == "PlayerRight")
        {
            collided = false;
        }
    }
}

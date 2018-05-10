using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaberCollision : MonoBehaviour {

    SteamVR_Controller.Device device { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
    SteamVR_TrackedObject trackedObj;
    GameObject tracked;
    public float timeAlive = 0.0f;
    public float timeEntered = 0.0f;
    public float distance = 0.0f;
    public int score = 0;
    public static GameObject DifficultyManager;
    private bool inReactionArea, collided;
	// Use this for initialization
	void Start () {
        tracked = GameObject.Find("Controller (left)");
		    trackedObj = tracked.GetComponent<SteamVR_TrackedObject>();
        DifficultyManager = GameObject.Find("Spawner");
        inReactionArea = false;
        collided = false;
   }
	
	// Update is called once per frame
	void Update () {
        timeAlive += 1.0f*Time.deltaTime;
        if (inReactionArea && collided)
        {
            if (device.velocity.sqrMagnitude > 1)
            {
                string hitbox = "Reaction";
                GameObject hitBox = GameObject.FindGameObjectWithTag(hitbox);
                distance = Mathf.Abs(transform.position.z - hitBox.transform.position.z);

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

                Debug.Log("Score: " + score);
                DifficultyManager.GetComponent<DifficultyManager>().IncrementNotesHit(score);
                SteamVR_Controller.Input(4).TriggerHapticPulse(3999);
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerLeft")
        {
            SteamVR_Controller.Input(3).TriggerHapticPulse(3999);
            collided = true;
        }
        if (other.tag == "Respawn")
        {
            this.GetComponent<ParticleSystem>().startColor = new Color(255, 255, 255, 255);
        }

        if (other.tag == "Reaction")
        {
            this.GetComponent<ParticleSystem>().startColor = new Color(0, 0, 0, 255);
            inReactionArea = true;
        }


        if (device.velocity.sqrMagnitude > 50)
        {
            if (other.tag == "PlayerLeft" && inReactionArea)
            {
                string hitbox = "Reaction";
                GameObject hitBox = GameObject.FindGameObjectWithTag(hitbox);
                distance = Mathf.Abs(transform.position.z - hitBox.transform.position.z);

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

                Debug.Log("Score: " + score);
                //SteamVR_Controller.Input(3).TriggerHapticPulse(3999);
                DifficultyManager.GetComponent<DifficultyManager>().IncrementNotesHit(score);
                Destroy(gameObject);
            }
        }
        else if (other.tag == "Reaction")
        {
            timeEntered = timeAlive;
        }
        //Debug.Log(message: timeEntered);
    }
    private void OnTriggerExit(Collider other) {
        if (other.tag == "Reaction") {
            DifficultyManager.GetComponent<DifficultyManager>().BreakStreak();
            inReactionArea = false;
        }
        else if (other.tag == "PlayerLeft") {
            collided = false;
        }
    }
}

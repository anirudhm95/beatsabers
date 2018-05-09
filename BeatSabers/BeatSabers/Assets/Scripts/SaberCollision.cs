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
	// Use this for initialization
	void Start () {
        tracked = GameObject.Find("Controller (left)");
		    trackedObj = tracked.GetComponent<SteamVR_TrackedObject>();
        DifficultyManager = GameObject.Find("Spawner");       
   }
	
	// Update is called once per frame
	void Update () {
        timeAlive += 1.0f*Time.deltaTime;
	}

    private void OnTriggerEnter(Collider other)
    {

            if (other.tag == "Respawn")
        {
            this.GetComponent<ParticleSystem>().startColor = new Color(255, 255, 255, 255);
        }

        if (other.tag == "Reaction")
        {
            this.GetComponent<ParticleSystem>().startColor = new Color(0, 0, 0, 255);
        }


        if (device.velocity.sqrMagnitude > 1)
        {
            if (other.tag == "PlayerLeft")
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
                Destroy(gameObject);
                SteamVR_Controller.Input(1).TriggerHapticPulse(3999);
                DifficultyManager.GetComponent<DifficultyManager>().incrementNotesHit();
            }
        }
        else if (other.tag == "Reaction")
        {
            timeEntered = timeAlive;
        }
        //Debug.Log(message: timeEntered);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaberCollision : MonoBehaviour {

    public float timeAlive = 0.0f;
    public float timeEntered = 0.0f;
    public static GameObject DifficultyManager;
    // Use this for initialization
    void Start () {
        DifficultyManager = GameObject.Find("Spawner");       
    }
	
	// Update is called once per frame
	void Update () {
        timeAlive += 1.0f*Time.deltaTime;
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            DifficultyManager.GetComponent<DifficultyManager>().incrementNotesHit();
            Destroy(gameObject);
        }
        else if (other.tag == "Reaction")
        {
            timeEntered = timeAlive;
        }
        Debug.Log(message: timeEntered);
    }
}

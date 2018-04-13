using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaberCollision : MonoBehaviour {


    public static GameObject DifficultyManager;
    // Use this for initialization
    void Start () {
        DifficultyManager = GameObject.Find("Spawner");

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            DifficultyManager.GetComponent<DifficultyManager>().incrementNotesHit();
            Destroy(gameObject);
        }
        Debug.Log(message: other.tag);
    }
}

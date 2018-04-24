using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCollision : MonoBehaviour {

    public static GameObject DifficultyManager;
    // Use this for initialization
    void Start()
    {
        DifficultyManager = GameObject.Find("Spawner");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerLeft")
        {
            DifficultyManager.GetComponent<DifficultyManager>().incrementLasersFailed();
        }
    }
}

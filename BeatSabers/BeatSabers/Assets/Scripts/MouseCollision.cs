using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
        }
        if (other.tag == "projectile")
        {
            Debug.Log("Collision Detected box");
        }
        Debug.Log(message: other.tag);
    }
}

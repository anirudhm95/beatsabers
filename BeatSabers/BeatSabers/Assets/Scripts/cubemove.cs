using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubemove : MonoBehaviour {

    private float speed = 6.0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
}

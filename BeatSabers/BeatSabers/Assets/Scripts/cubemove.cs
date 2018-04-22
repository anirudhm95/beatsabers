using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubemove : MonoBehaviour {

    private static float moveSpeed = 9.0f;
    private float modifier = 0.0f;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, 0, (moveSpeed+modifier) * Time.deltaTime);

        if (transform.position.z <= -50.0f && moveSpeed == 6.0f)
            Destroy(gameObject);
    }

    public void setModifier(float mod) {
        modifier = mod;
    }
}

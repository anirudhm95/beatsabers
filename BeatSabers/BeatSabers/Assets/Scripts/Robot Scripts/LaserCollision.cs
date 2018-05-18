using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCollision : MonoBehaviour {

    public static GameObject DifficultyManager;
    private bool hasCollided = false;
    // Use this for initialization
    void Start()
    {
        DifficultyManager = GameObject.Find("Spawner");
    }

    // Update is called once per frame
    void Update() {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MainCamera")
        {
            Debug.Log("HIT HIT HIT");
            DifficultyManager.GetComponent<DifficultyManager>().IncrementLasersFailed();
        }
    }

    public void LaserDodged() {
        if (!hasCollided)
            DifficultyManager.GetComponent<DifficultyManager>().IncrementLasersDodged();
        Destroy(gameObject);
    }
}

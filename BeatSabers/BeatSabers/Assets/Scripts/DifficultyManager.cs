using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour {

    public int numNotesSpawned = 0;
    public int numNotesHit = 0;
    public float numNotesPrecision = 0.0f;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        if (numNotesSpawned > 0)
            numNotesPrecision = numNotesHit / (float)numNotesSpawned;
    }

    public void incrementNotesSpawned() {
        numNotesSpawned++;
    }

    public void incrementNotesHit()
    {
        numNotesHit++;
    }
}

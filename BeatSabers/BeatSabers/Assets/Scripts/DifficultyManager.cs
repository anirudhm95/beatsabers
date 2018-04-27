using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour {

    public int numNotesSpawned = 0;
    public int numNotesHit = 0;
    public float numNotesPrecision = 0.0f;
    public int numLasersDodged = 0;
    public int numLasersFailed = 0;
    public int numLastChecked = 0;
    public float modifier = 0.0f;
    private static float moveSpeed = 6.0f;

    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update() {
        if (numNotesSpawned > 0)
            numNotesPrecision = numNotesHit / (float)numNotesSpawned;

        if (numNotesSpawned > numLastChecked + 50) {
            numLastChecked = numNotesSpawned;
            modifier++;
            GetComponent<AudioHelm.Spawner>().updateMoveSpeed(120f, modifier);
        }
    }

    public void incrementNotesSpawned() {
        numNotesSpawned++;
    }

    public void incrementNotesHit()
    {
        numNotesHit++;
    }

    public void incrementLasersFailed()
    {
        numLasersFailed++;
    }

    public float getModifier() {
        return modifier;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour {

	PlayerProgressHolder playerprogress;
	public static PlayerData playerData = new PlayerData ();

    public int numNotesSpawned = 0;
    public int numNotesHit = 0;
	public int earlyHit = 23;
	public int perfectHit = 70;
	public int missHit = 30;
    public float numNotesPrecision = 0.0f;
    public int numLastChecked = 0;
    public float modifier = 0.0f;
    private static float moveSpeed = 6.0f;
	public bool hasFinished = false;

	void Awake () {
		playerprogress = FindObjectOfType<PlayerProgressHolder>();
	}

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

		if (numNotesSpawned == 60) {
			Debug.Log ("Line 41"); 
			SaveData.playerData.currentSong = "BeatSabers";
			SaveData.playerData.timeStamp = 3.0f;
			SaveData.playerData.score = 450;
			SaveData.playerData.earlyHit = earlyHit;
			SaveData.playerData.perfectHit = perfectHit;
			SaveData.playerData.Miss = missHit;
			SaveData.playerData.currentStreak = 60;
			SaveData.playerData.noOfOrbsSpawning = numNotesSpawned;
			SaveData.playerData.precision = 1.0f;
			SaveData.playerData.map = "Forest";
			SaveData.playerData.difficulty = "Easy";

			playerprogress.GetComponent<PlayerProgressHolder> ().Save ();
			//SaveData.Save(SaveData.playerData.path);
			Debug.Log("Line 54");


		}

    }

    public void incrementNotesSpawned() {
        numNotesSpawned++;
    }

    public void incrementNotesHit()
    {
        numNotesHit++;
    }

    public float getModifier() {
        return modifier;
    }
}

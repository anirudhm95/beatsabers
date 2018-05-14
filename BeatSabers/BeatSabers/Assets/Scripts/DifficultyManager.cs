using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyManager : MonoBehaviour {
    PlayerProgressHolder playerprogress;
    public static PlayerData playerData = new PlayerData();

    public GameObject sequencer;
    public int numNotesSpawned = 0;
    public int numNotesHit = 0;
	public int earlyHit = 0;
	public int perfectHit = 0;
	public int missHit = 0;
    public float numNotesPrecision = 0.0f;
    public int numLasersDodged = 0;
    public int numLasersFailed = 0;
    public int numLastChecked = 0;
    public int currentStreak = 0;
    public int maxStreak = 0;
    public int score = 0;
    private bool GameEnded = false;
    public float modifier = 0.0f;
    private static float moveSpeed = 6.0f;
	public bool hasFinished = false;

	void Awake () {
		playerprogress = FindObjectOfType<PlayerProgressHolder>();
	}

    // Use this for initialization
    void Start () {
        playerprogress = FindObjectOfType<PlayerProgressHolder>();
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

		if (GameEnded) {
			Debug.Log ("Line 41"); 
			SaveData.playerData.currentSong = "BeatSabers";
			SaveData.playerData.timeStamp = maxStreak;
			SaveData.playerData.score = score;
			SaveData.playerData.earlyHit = earlyHit;
			SaveData.playerData.perfectHit = perfectHit;
			SaveData.playerData.Miss = missHit;
			SaveData.playerData.currentStreak = currentStreak;
			SaveData.playerData.noOfOrbsSpawning = numNotesSpawned;
			SaveData.playerData.precision = numNotesPrecision;
			SaveData.playerData.map = "Forest";
			SaveData.playerData.difficulty = "Easy";

            playerprogress.GetComponent<PlayerProgressHolder> ().Save ();
			//SaveData.Save(SaveData.playerData.path);
			Debug.Log("Line 54");
            numNotesSpawned = 31;
            GameEnded = false;
            SceneManager.LoadScene("NewMenu");
        }

    }

    public void incrementNotesSpawned() {
        numNotesSpawned++;
    }

    public void IncrementNotesHit(int Score)
    {
        if (Score == 5)
            perfectHit++;
        else if (Score == 2)
            earlyHit++;
        numNotesHit++;
        currentStreak++;
        score += Score;
    }

    public void incrementLasersFailed()
    {
        numLasersFailed++;
    }

    public float getModifier() {
        return modifier;
    }

    public void BreakStreak() {
        if (currentStreak > maxStreak) {
            maxStreak = currentStreak;
        }
        currentStreak = 0;
        missHit++;
    }

    public void SetGameEnded(bool isEnded) {
        GameEnded = isEnded;
    }
}

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
            ManageDifficulty();
        }

		if (GameEnded)
            EndGame();
    }

    //Updates player data, saves data and loads new menu at end of song
    void EndGame() {
        SaveData.playerData.currentSong = SaveData.createGameData.nameOfSong;
        SaveData.playerData.timeStamp = maxStreak;
        SaveData.playerData.score = score;
        SaveData.playerData.earlyHit = earlyHit;
        SaveData.playerData.perfectHit = perfectHit;
        SaveData.playerData.Miss = missHit;
        SaveData.playerData.currentStreak = currentStreak;
        SaveData.playerData.noOfOrbsSpawning = numNotesSpawned;
        SaveData.playerData.precision = numNotesPrecision;
        SaveData.playerData.map = SaveData.createGameData.map;
        SaveData.playerData.difficulty = "Easy";

        playerprogress.GetComponent<PlayerProgressHolder>().Save();
        GameEnded = false;
        SceneManager.LoadScene("NewMenu");
    }

    //determines how difficulty should be modified and changes orb move speed 
    void ManageDifficulty() {
        numLastChecked = numNotesSpawned;
        if (numNotesPrecision > 0.8f)
        {
            modifier++;
            GetComponent<AudioHelm.Spawner>().UpdateMoveSpeed(modifier);
        }
        else if (numNotesPrecision < 0.6f && modifier > -9.0f)
        {
            modifier--;
            GetComponent<AudioHelm.Spawner>().UpdateMoveSpeed(modifier);
        }
    }

    public void IncrementNotesSpawned()
    {
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

    public void IncrementLasersFailed()
    {
        numLasersFailed++;
    }

    public float GetModifier()
    {
        return modifier;
    }

    public void BreakStreak()
    {
        if (currentStreak > maxStreak)
        {
            maxStreak = currentStreak;
        }
        currentStreak = 0;
        missHit++;
    }

    public void SetGameEnded(bool isEnded)
    {
        GameEnded = isEnded;
    }
}

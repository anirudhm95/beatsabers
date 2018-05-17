using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public PlayerData data = new PlayerData ();

	public string playerName;
	public string playerID;
	public string currentSong;
	public int score;
	public int earlyHit;
	public int perfectHit;
	public int Miss;
	public int currentStreak;
	public int noOfOrbsSpawning;
	public float precision;
	public float timeStamp;

	public void StoreData(){
		
		data.playerName = playerName;
		data.playerID = playerID;
		data.currentSong = currentSong;
		data.score = score;
		data.earlyHit = earlyHit;
		data.perfectHit = perfectHit;
		data.Miss = Miss;
		data.currentStreak = currentStreak;
		data.noOfOrbsSpawning = noOfOrbsSpawning;
		data.precision = precision;
		data.timeStamp = timeStamp;
	
	}

	public void loadData(){
		
		playerName = data.playerName;
		playerID = data.playerID;
		currentSong = data.currentSong;
		score = data.score;
		earlyHit = data.earlyHit;
		perfectHit = data.perfectHit;
		Miss = data.Miss;
		currentStreak = data.currentStreak;
		noOfOrbsSpawning = data.noOfOrbsSpawning;
		precision = data.precision;
		timeStamp = data.timeStamp; 

	}



}

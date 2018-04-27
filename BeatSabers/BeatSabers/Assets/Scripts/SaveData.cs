using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveData  {

	// public static GameContainer gamecontainer = new GameContainer();
	// make it static so we can call it from anywhere
	public static PlayerData playerData = new PlayerData();

	public static void Save(string path)
	{
		SavePlayerData(path);
	}

	public static void Load()
	{
		LoadPlayerData();
	}

	public static void CreateNewGameData(string playername)
	{
		playerData.playerName = playername;
		SaveData.Save("Assets/Resources/Game_Data_" + playername + ".csv");

	}

	private static void LoadPlayerData()
	{


		string[] readData;
		char[] fieldSeparators = { ',' };

		StreamReader inputStream = new StreamReader("Assets/Resources/Game_Data_" + playerData.playerName + ".csv");

		string data = inputStream.ReadLine();
		data = inputStream.ReadLine();


		readData = data.Split(fieldSeparators);
		playerData.playerName = readData[0];
		playerData.playerID = readData[1];
		playerData.currentSong = readData[2];
		float.TryParse(readData[3] , out playerData.timeStamp);
		int.TryParse(readData[4] , out playerData.score);
		int.TryParse(readData[5] , out playerData.earlyHit);
		int.TryParse(readData[6] , out playerData.perfectHit);
		int.TryParse(readData[7] , out playerData.Miss);
		int.TryParse(readData[8] , out playerData.currentStreak);
		int.TryParse(readData[9] , out playerData.noOfOrbsSpawning);
		float.TryParse(readData[10], out playerData.precision);


		// for testing
		Debug.Log(playerData.playerName + "," + playerData.playerID + "," + playerData.currentSong + "," + playerData.timeStamp + "," + playerData.score + "," + 
			playerData.earlyHit + "," + playerData.perfectHit + "," + playerData.Miss + "," + playerData.currentStreak + "," + playerData.noOfOrbsSpawning + "," + playerData.precision);


	}

	private static void SavePlayerData(string path)
	{


		StreamWriter outStream = System.IO.File.CreateText (path);
		// write column header
		outStream.WriteLine ("playerName, playerID, CurrentSong, timeStamp, score, earlyHit, perfectHit, Miss, currentStreak, noOfOrbsSpawning, precision");

		/*
        // test data
		playerData.playerName = "em";
		playerData.playerID = "12345";
		playerData.currentSong = "abcd";
		playerData.timeStamp = 3.0f;
		playerData.score = 150;
		playerData.earlyHit = 15;
		playerData.perfectHit = 45;
		playerData.Miss = 50;
		playerData.currentStreak = 25;
		playerData.noOfOrbsSpawning = 200;
		playerData.precision = 1.0f;
		*/
		outStream.WriteLine (playerData.playerName +
		"," + playerData.playerID +
		"," + playerData.currentSong +
		"," + " " + playerData.timeStamp +
		"," + playerData.score.ToString () +
		"," + playerData.earlyHit.ToString () +
		"," + playerData.perfectHit.ToString () +
		"," + playerData.Miss.ToString () +
		"," + playerData.currentStreak.ToString () +
		"," + playerData.noOfOrbsSpawning.ToString () +
		"," + playerData.precision.ToString ());

		outStream.Flush ();
		outStream.Close ();     


	}
}

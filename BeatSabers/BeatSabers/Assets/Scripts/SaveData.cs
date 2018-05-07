using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveData  {

	// public static GameContainer gamecontainer = new GameContainer();
	// make it static so we can call it from anywhere
	public static PlayerData playerData = new PlayerData();
	//public static CreateGameData createGameData = new CreateGameData ();


	public static void Save(string path)
	{
		SavePlayerData(path);
		//SaveCreatedGameData(path);
	}
		

	public static void Load()
	{
		
		LoadPlayerData();
		//LoadCreateGameData ();
	}
		

	public static void CreateNewPlayerData(string playername)
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
	/*
	private static void LoadCreateGameData(){

		string[] readData;
		char[] fieldSeparators = { ',' };

		StreamReader inputStream = new StreamReader ("Assets/Resources/CreatedGame_Data.csv");

		string data = inputStream.ReadLine ();
		data = inputStream.ReadLine ();

		readData = data.Split (fieldSeparators);
		createGameData.playerName = readData [0];
		createGameData.nameOfSong = readData [1];
		createGameData.map = readData [2];
		createGameData.difficulty = readData [3];
	}*/

	private static void SavePlayerData(string path)
	{
		 

		Debug.Log (path);
		StreamWriter outStream = System.IO.File.AppendText(path);

		                                                                                                                                                                                                                                                                             //if ((firstLine = stream.ReadLine ()) != null) {
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
				"," + playerData.precision.ToString () +
				"," + playerData.map +
				"," + playerData.difficulty);

				outStream.Flush ();
				outStream.Close (); 
			

	}
	/*
	private static void SaveCreatedGameData(string path){

		StreamWriter outStream = System.IO.File.AppendText(path);
		outStream.WriteLine ("playerName, nameOfSong, map, difficulty");


		//test data

		createGameData.playerName = "hung";
		createGameData.nameOfSong = "abcd";
		createGameData.map = "Forest";
		createGameData.difficulty = "Easy";

		outStream.WriteLine (createGameData.playerName +
			"," + createGameData.nameOfSong +
			"," + createGameData.map +
			"," + createGameData.difficulty);

		outStream.Flush ();
		outStream.Close ();
	}*/
			
}


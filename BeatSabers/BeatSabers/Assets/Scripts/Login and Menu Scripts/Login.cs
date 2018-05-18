using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.IO;

public class Login : MonoBehaviour {

	PlayerProgressHolder playerprogress;
	public static PlayerData playerData = new PlayerData ();



	public GameObject PlayerName;
	public GameObject PlayerID;

	private string playerName;
	private string playerID;



	void Awake () {
		playerprogress = FindObjectOfType<PlayerProgressHolder>();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			if (PlayerName.GetComponent<InputField>().isFocused)
			{
				PlayerID.GetComponent<InputField>().Select();

			}
		}

		if (Input.GetKeyDown(KeyCode.Return))
		{
			if(playerID != "") 
			{
				LoginButton();
			}
		}


		playerName = PlayerName.GetComponent<InputField>().text;
		playerID = PlayerID.GetComponent<InputField>().text;

	}

	public void LoginButton()
	{
		SaveData.playerData.playerName = PlayerName.GetComponent<InputField>().text;
		SaveData.playerData.playerID = PlayerID.GetComponent<InputField>().text;

		String playerFile = "Assets/Resources/Game_Data_" + playerName + ".csv";
		SaveData.playerData.playerName = playerName;
        playerprogress.SetDataPath(playerFile);
		if (File.Exists(playerFile))
		{
			SaveData.Load();


			if (playerName == SaveData.playerData.playerName && playerID  == SaveData.playerData.playerID)
			{
				
				Debug.Log("Login Successful");
				SceneManager.LoadScene("NewMenu");
			}
			else
			{
				Debug.Log("Invalided playerName/playerID");
			}

		}
		else
		{  
			StreamWriter outStream = System.IO.File.AppendText(playerFile);
			outStream.WriteLine ("playerName, playerID, CurrentSong, timeStamp, score, earlyHit, lateHit, perfectHit, Miss, currentStreak, noOfOrbsSpawning, precision, map");
			outStream.Close ();
	        GenerateNewFile(SaveData.playerData.playerName);
            SceneManager.LoadScene("NewMenu");
		}
	}

	public void GenerateNewFile(String playerName)
	{

		SaveData.CreateNewPlayerData(playerName);

	}

}

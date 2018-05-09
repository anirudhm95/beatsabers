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
				//SaveData.Save(playerFile);
				Debug.Log("Login Successful");
				Debug.Log(playerName + "," + playerID);
				Debug.Log(SaveData.playerData.playerName + "," +  SaveData.playerData.playerID);
				SceneManager.LoadScene("Game");
			}
			else
			{
				Debug.Log("Invalided playerName/playerID");
			}

		}
		else
		{
			GenerateNewFile(SaveData.playerData.playerName);
			SaveData.Save(playerFile);
			SceneManager.LoadScene("Game");
		}
	}

	public void GenerateNewFile(String playerName)
	{


		SaveData.CreateNewGameData(playerName);

	}

}

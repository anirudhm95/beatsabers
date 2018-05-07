using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerProgressHolder : MonoBehaviour {

		
		public bool GameLoaded { get; private set; }

		public static string dataPath = string.Empty;
		//public static string createGameFile = string.Empty;

		void Awake()
		{

			dataPath = "Assets/Resources/Game_Data_"  + SaveData.playerData.playerName + ".csv";
			SaveData.playerData.path = dataPath;
			//createGameFile = "Assets/Resources/CreatedGame_Data.csv";
		    

			// to keep game data and this game object live througout the life cycle of the game
			DontDestroyOnLoad(gameObject);
		}
		// Use this for initialization
		void Start () {

			GameLoaded = true;
			
		}
		

		public void Save()
		{
			SaveData.Save(dataPath);
			Debug.Log("Game Saved");
		   // SaveData.Save(createGameFile);
			//Debug.Log ("Created Game Saved");
		}

		void Load()
		{
			SaveData.Load();
			Debug.Log("Game Loaded");
			//SaveData.Load();
			//Debug.Log ("Created Game Loaded");
		}
		
		public void setDataPath(string path){
		dataPath = path;
	}
}


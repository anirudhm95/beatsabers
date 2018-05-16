using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.IO;


public class CreateGame : MonoBehaviour{
	

	PlayerProgressHolder playerprogress;
	public static CreateGameData data = new CreateGameData ();




	// Use this for initialization
	void Awake () {
		playerprogress = FindObjectOfType<PlayerProgressHolder>();
        data.map = "Game";
        SaveData.createGameData.nameOfSong = "Meltdown";
        SaveData.createGameData.songIndex = 0;
        SaveData.createGameData.bpm = 165;
    }

	// Update is called once per frame
	void Update () {

		//if (Input.GetKeyDown(KeyCode.Return))
	    //	{
	    //		StartButton ();
        //	}

	}

	public void StartButton(){

		string ScientistFile = "Assets/Resources/Scientist_CreateGame.csv";



		if (File.Exists (ScientistFile)) {

			//SaveData.Loads ();
			Debug.Log ("File exists");
			SceneManager.LoadScene(data.map);

		} else {

			StreamWriter outStream = System.IO.File.AppendText("Assets/Resources/Scientist_CreateGame.csv");
			outStream.WriteLine ("playerName, nameOfSong, map, difficulty");

			outStream.Flush ();
			outStream.Close ();
			SceneManager.LoadScene(data.map);

		}
	}

    public void SetGameLevel(string GameLevel) {
        data.map = GameLevel;
        SaveData.createGameData.map = GameLevel;
    }

    public void SetSong(string GameSong) {
        data.nameOfSong = GameSong;
        SaveData.createGameData.nameOfSong = GameSong;
    }

    public void SetSongIndex(int GameSongIndex)
    {
        data.songIndex = GameSongIndex;
        SaveData.createGameData.songIndex = GameSongIndex;
    }

    public void SetBPM(int bpm) {
        data.bpm = bpm;
        SaveData.createGameData.bpm = bpm;
    }
}


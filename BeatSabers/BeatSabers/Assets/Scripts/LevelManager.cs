using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour {



	void Update(){

		if (Input.GetKeyDown(KeyCode.Return))
		{
			 

				CreateGameButton();

		}
	}


	public void LoadLevel (string name)
	{
		Debug.Log ("Level load requested for: " + name);
		Application.LoadLevel(name);
	}

	public void QuitRequest(){
		Debug.Log("I want to quit!");
		Application.Quit();

	}

	public void CreateGameButton(){

		SceneManager.LoadScene("CreateGame");
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour {

	public string sceneToLoad = "NewMenu";

	public PlayerProgressHolder plyerprogress;
	
	// Update is called once per frame
	void Update () {
		if (plyerprogress.GameLoaded)
		{
			SceneManager.LoadScene (sceneToLoad);
		}
		
	}
}

using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LoadonClick : MonoBehaviour {

	public void LoadByIndex(int sceneIndex)
	{
		SceneManager.LoadScene (sceneIndex);

	}
}

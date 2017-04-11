using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour {

	private string currentScene;

	void Update ()
	{
		
	}

	// Use this for initialization
	void Start () 
	{
		currentScene = SceneManager.GetActiveScene ().name;
		if (SceneManager.GetSceneByName ("GameScene").name == currentScene)
		{
			SceneManager.LoadScene("UI", LoadSceneMode.Additive);
		}
	}
}

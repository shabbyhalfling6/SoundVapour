using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour {

	private string currentScene;

	// Use this for initialization
	void Start () 
	{
		currentScene = SceneManager.GetActiveScene ().name;
	/*+++++++++++++++++++++++++++++++++++++
	 * ADDS THE UI SCENE TO OVERLAY GAME
	 ++++++++++++++++++++++++++++++++++++++*/
		if (SceneManager.GetSceneByName ("GameScene").name == currentScene)
		{
			SceneManager.LoadScene("UI", LoadSceneMode.Additive);
		}
	}

	/*+++++++++++++++++++++++++++++++++++++
	 * SCENE LOADING FUNCTIONS
	 ++++++++++++++++++++++++++++++++++++++*/
	public void LoadGameScene()
	{
		SceneManager.LoadScene ("GameScene");
	}
	public void LoadOptionsScene()
	{
		SceneManager.LoadScene ("Options");
	}
	public void LoadCreditsScene()
	{
		SceneManager.LoadScene ("Credits");
	}
	public void QuitGame()
	{
		Application.Quit();
		Debug.Log ("User Quit the game!");
	}
}

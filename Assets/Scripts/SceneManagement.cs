using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour {

	public static int currentSceneIndex;

	// Use this for initialization
	void Start () 
	{
		currentSceneIndex = SceneManager.GetActiveScene ().buildIndex;
	/*+++++++++++++++++++++++++++++++++++++
	 * ADDS THE UI SCENE TO OVERLAY GAME
	 ++++++++++++++++++++++++++++++++++++++*/
		if (currentSceneIndex > 3)
		{
			SceneManager.LoadScene("UI", LoadSceneMode.Additive);
		}
	}

	/*+++++++++++++++++++++++++++++++++++++
	 * SCENE LOADING FUNCTIONS
	 ++++++++++++++++++++++++++++++++++++++*/
	public void LoadMenuSceneFromPaused()
	{
		GameObject.Find("Laser").GetComponent<PlayerInput>().pauseToggle ();
		SceneManager.LoadScene ("Menu");
	}
	public void LoadMenuScene()
	{
		SceneManager.LoadScene ("Menu");
	}
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

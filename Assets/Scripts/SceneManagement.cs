﻿using System.Collections;
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
		if (currentSceneIndex > 4)
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
	public void LoadSongSelectScene()
	{
		SceneManager.LoadScene ("SongSelect");
	}
	public void LoadBlipStreamScene()
	{
		SceneManager.LoadScene ("GameScene");
	}
	public void LoadPartySongScene()
	{
		SceneManager.LoadScene ("GameScene 1");
	}
	public void LoadCreoScene()
	{
		SceneManager.LoadScene ("GameScene 2");
	}
    public void LoadWolfScene()
    {
        SceneManager.LoadScene ("GameScene 3");
    }        
	public void LoadOptionsScene()
	{
		SceneManager.LoadScene ("Options");
	}
	public void LoadCreditsScene()
	{
		SceneManager.LoadScene ("Credits");
	}
	public void RetryLevel ()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
	public void QuitGame()
	{
		Application.Quit();
		Debug.Log ("User Quit the game!");
	}
}

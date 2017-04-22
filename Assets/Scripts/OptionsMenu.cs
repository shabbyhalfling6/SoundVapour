using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour {

	public Slider musicSlider;
	public Slider sfxSlider;
	public static float customMusicVol;
	public static float customSFXVol;
	public Dropdown ResetLevelScore;
	public Button ResetConfirm;
	public Text CurrentHighScore;

	// Use this for initialization
	void Start () 
	{
		ResetConfirm.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		customMusicVol = musicSlider.value;
		customSFXVol = sfxSlider.value;

		if(ResetLevelScore.GetComponentInChildren<Text>().text == "Select Level")
		{
			ResetConfirm.gameObject.SetActive (false);
		}

		ReadHighScoreData ();
	}

	public void EnableConfirmButton()
	{
		ResetConfirm.gameObject.SetActive(true);
	}

	public void HandleDropDown()
	{
		if (ResetConfirm.isActiveAndEnabled) 
		{
			if(ResetLevelScore.GetComponentInChildren<Text>().text == "Level 1")
			{
				PlayerScore.HighScore1 = 0;
				PlayerPrefs.SetInt ("TopScore1", PlayerScore.HighScore1);
				ResetConfirm.gameObject.SetActive (false);
				musicSlider.Select ();
			}
			if(ResetLevelScore.GetComponentInChildren<Text>().text == "Level 2")
			{
				PlayerScore.HighScore2 = 0;
				PlayerPrefs.SetInt ("TopScore2", PlayerScore.HighScore2);
				ResetConfirm.gameObject.SetActive (false);
				musicSlider.Select ();
			}
			if(ResetLevelScore.GetComponentInChildren<Text>().text == "Level 3")
			{
				PlayerScore.HighScore3 = 0;
				PlayerPrefs.SetInt ("TopScore3", PlayerScore.HighScore3);
				ResetConfirm.gameObject.SetActive (false);
				musicSlider.Select ();
			}
		}
	}

	public void ReadHighScoreData()
	{
		if(ResetLevelScore.GetComponentInChildren<Text>().text == "Level 1")
		{
			CurrentHighScore.text = "This Current High Score is " + PlayerPrefs.GetInt ("TopScore1").ToString ();
		}
		if(ResetLevelScore.GetComponentInChildren<Text>().text == "Level 2")
		{
			CurrentHighScore.text = "This Current High Score is " + PlayerPrefs.GetInt ("TopScore2").ToString ();
		}
		if(ResetLevelScore.GetComponentInChildren<Text>().text == "Level 3")
		{
			CurrentHighScore.text = "This Current High Score is " + PlayerPrefs.GetInt ("TopScore3").ToString ();
		}
		if(ResetLevelScore.GetComponentInChildren<Text>().text == "Select Level")
		{
			CurrentHighScore.text = "Select Level";
		}
	}
}


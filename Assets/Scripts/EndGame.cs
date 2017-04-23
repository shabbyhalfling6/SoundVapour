using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : SceneManagement {

	public Text runScoreText;
	public Text topScoreText;
	public Text EndTitleText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		runScoreText.text = PlayerScore.Instance.currentScore.ToString();
		if(SceneManagement.currentSceneIndex == 5)
		{
			topScoreText.text = PlayerPrefs.GetInt ("TopScore1").ToString ();
		}
		if(SceneManagement.currentSceneIndex == 6)
		{
			topScoreText.text = PlayerPrefs.GetInt ("TopScore2").ToString ();
		}
		if(SceneManagement.currentSceneIndex == 7)
		{
			topScoreText.text = PlayerPrefs.GetInt ("TopScore3").ToString ();
		}

		if (GameController.Instance.lose == true) 
		{
			EndTitleText.text = "Song Failed";
			EndTitleText.color = Color.red;
		}
		if (GameController.Instance.win == true) 
		{
			EndTitleText.text = "Song Completed!";
			EndTitleText.color = Color.green;
		}
	}
}

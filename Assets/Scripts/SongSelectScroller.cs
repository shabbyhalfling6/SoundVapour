using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongSelectScroller : SceneManagement {

	public Scrollbar SongScroll;
	private int numberOfSongs;
	public float scrollIncrement;
	public float scrollDelay = 0.1f;
	public Text song1TopScore;
	public Text song1Difficulty;
	public Text song2TopScore;
	public Text song2Difficulty;
	public Text song3TopScore;
	public Text song3Difficulty;
	public Text song4TopScore;
	public Text song4Difficulty;
	public Text song5TopScore;
	public Text song5Difficulty;

	// Use this for initialization
	void Start () {
		numberOfSongs = transform.childCount;
		scrollIncrement = 1f / (float)numberOfSongs;
		song1TopScore.text = "Top Score: " + PlayerPrefs.GetInt ("TopScore1").ToString ();
		song2TopScore.text = "Top Score: " + PlayerPrefs.GetInt ("TopScore2").ToString ();
		song3TopScore.text = "Top Score: " + PlayerPrefs.GetInt ("TopScore3").ToString ();
		song4TopScore.text = "Top Score: " + PlayerPrefs.GetInt ("TopScore4").ToString ();
		song5TopScore.text = "Top Score: " + PlayerPrefs.GetInt ("TopScore5").ToString ();
		song1Difficulty.text = "Song Difficulty: ooooo";
		song2Difficulty.text = "Song Difficulty: oo";
		song3Difficulty.text = "Song Difficulty: oooo";
		song4Difficulty.text = "Song Difficulty: -";
		song5Difficulty.text = "Song Difficulty: -";
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (scrollDelay <= 0f) 
		{
			scrollDelay = 0.1f;
		}
		if (Input.GetAxis ("Vertical") < -0.19f) 
		{
			scrollDelay -= Time.deltaTime;
			if (scrollDelay <= 0f) 
			{
				SongScroll.value = SongScroll.value - scrollIncrement;
			}
		}
		if (Input.GetAxis ("Vertical") > 0.19f) 
		{
			scrollDelay -= Time.deltaTime;
			if (scrollDelay <= 0f) 
			{
				SongScroll.value = SongScroll.value + scrollIncrement;
			}
		}

		if (Input.GetAxis ("Cancel") == 1) 
		{
			LoadMenuScene ();
		}
	}
}

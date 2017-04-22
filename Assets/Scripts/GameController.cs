using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public AudioSource audibleTrack;
	public AudioSource spawnerTrack;
	public bool lose = false;
    public bool win = false;
    public bool triggered = false;
	public float songDuration;
	public float remainingTime;
    private float songDelay = 2.2f;

    public static GameController _instance;

    public BoxCollider2D box;

	private GameObject endScreen;

    void Awake()
    {
        if (_instance != null)
            Destroy(this.gameObject);
        else
            _instance = this;

        //add delay to audible track
        audibleTrack.PlayDelayed(songDelay);
    }

	void Start()
	{
		audibleTrack.volume = OptionsMenu.customMusicVol;
		songDuration = audibleTrack.clip.length;
		remainingTime = songDuration;
		endScreen = GameObject.Find ("GameEnd");
		endScreen.SetActive (false);
	}

    void Update()
    {
		//Checks Player input script to see if player paused the game and pauses the audio track if so.
		if (PlayerInput.isPaused == true) 
		{
			audibleTrack.Pause();
			spawnerTrack.Pause();
		}
		if (PlayerInput.isPaused == false) 
		{
			audibleTrack.UnPause();
			spawnerTrack.UnPause();
			remainingTime -= Time.deltaTime;
		}

        if(lose)
        {
            audibleTrack.Stop();
            spawnerTrack.Stop();
            Time.timeScale = 0.0f;
			endScreen.SetActive (true);
        }

		if (remainingTime < 0f && !lose) 
		{
			win = true;
			Time.timeScale = 0.0f;
			endScreen.SetActive (true);
		} 
		else 
		{
			win = false;
		}

		//prevents user being able to bring up pause menu when the game is over
		if (win == true || lose == true) 
		{
			PlayerInput.isPaused = false;
		}
    }

    //returns the instance of itself
    public static GameController Instance
    {
        get
        {
            return _instance;
        }
    }
}

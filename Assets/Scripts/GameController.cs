using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameController : MonoBehaviour
{
	public AudioSource audibleTrack;
	public AudioSource spawnerTrack;
	public float defaultMusicVolume = 1f;
	public bool lose = false;
    public bool win = false;
	public float songDuration;
	public float remainingTime;
    private float songDelay = 2.35f;
	public GameObject EndFirstSelectedButton;

    public static GameController _instance;

    public BoxCollider2D box;

	private GameObject endScreen;

	bool hasGameEnded = false;

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
		hasGameEnded = false;

		if (OptionsMenu.customOptionsLoaded == true) 
		{
			audibleTrack.volume = OptionsMenu.customMusicVol;
		} 
		else 
		{
			audibleTrack.volume = defaultMusicVolume;
		}

		Time.timeScale = 1f;
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

		if(lose && !hasGameEnded)
        {
            audibleTrack.Stop();
            spawnerTrack.Stop();
            endScreen.SetActive (true);
			SongEndButtonSelection ();
			Time.timeScale = 0.0f;
			hasGameEnded = true;
        }

		if (remainingTime < 0f && !lose) 
		{
			win = true;
			endScreen.SetActive (true);
			SongEndButtonSelection ();
			Time.timeScale = 0.0f;
			hasGameEnded = true;
		} 
		else 
		{
			win = false;
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
	public void SongEndButtonSelection()
	{
		EventSystem.current.firstSelectedGameObject = null;
		EndFirstSelectedButton = GameObject.Find ("Retry");
		EventSystem.current.SetSelectedGameObject(EndFirstSelectedButton);
	}
}

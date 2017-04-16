using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public AudioSource audibleTrack;
    public AudioSource spawnerTrack;

    public bool lose = false;
    public bool win = false;

    private float songDelay = 2.26f;

    public static GameController _instance;

    void Awake()
    {
        if (_instance != null)
            Destroy(this.gameObject);
        else
            _instance = this;

        //add delay to audible track
        audibleTrack.PlayDelayed(songDelay);
    }

    void Update()
    {
        if(lose)
        {
            audibleTrack.Stop();
            spawnerTrack.Stop();
            Time.timeScale = 0.0f;
        }

        if(audibleTrack.isPlaying)
        {
            win = true;
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerScore.Instance.hitCount = 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public AudioSource spawnerTrack;

    private bool gameOver = false;
    private float songDelay = 1.64f;

    public static GameController _instance;

    private void Awake()
    {
        if (_instance != null)
            Destroy(this.gameObject);
        else
            _instance = this;
    }

    //returns the instance of itself
    public static GameController Instance
    {
        get
        {
            return _instance;
        }
    }

    void Start()
    {
        //add delay to audible track
        spawnerTrack.PlayDelayed(songDelay);
    }
}

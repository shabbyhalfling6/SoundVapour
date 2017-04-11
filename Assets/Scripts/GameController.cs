using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public AudioSource audibleTrack;
    public AudioSource spawnerTrack;

    public bool gameOver = false;
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
        if(gameOver)
        {
            audibleTrack.Stop();
            spawnerTrack.Stop();
            Time.timeScale = 0.0f;
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

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shape")
        {
            GameController.Instance.gameOver = true;
        }
    }
}

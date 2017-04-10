using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public AudioSource spawnerTrack;

    void Start()
    {
        spawnerTrack.PlayDelayed(1.2f);
    }
}

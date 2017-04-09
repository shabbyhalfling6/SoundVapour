using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//is a singleton (only one instance of itself + globally accessible)
public class PlayerScore : MonoBehaviour
{
    public int currentMultiplier = 1;
    public int currentScore = 0;

    public static PlayerScore _instance;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else {
            _instance = this;
        }
    }

    //returns the instance of itself
    public static PlayerScore Instance
    {
        get
        {
            return _instance;
        }
    }

    public void RewardScore(int _hitCount, int _score)
    {
        //switch over the note hitCount and set the appropriate multiplier
        switch (_hitCount)
        {
            case 0:
                currentMultiplier = 1;
                break;
            case 25:
                currentMultiplier = 2;
                break;
            case 50:
                currentMultiplier = 3;
                break;
            case 75:
                currentMultiplier = 4;
                break;
            case 100:
                currentMultiplier = 5;
                break;
        }

        //update currentScore with the rewarded score and the updated multiplier
        currentScore += _score * currentMultiplier;
    }
}

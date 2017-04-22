using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//is a singleton (only one instance of itself + globally accessible)
public class PlayerScore : MonoBehaviour
{
    public int currentMultiplier = 1;
    public int currentScore = 0;
	public static int HighScore1;
	public static int HighScore2;
	public static int HighScore3;
    public int hitCount = 0;

    public const int hitStreak1 = 10;
    public const int hitStreak2 = 20;
    public const int hitStreak3 = 35;
    public const int hitStreak4 = 50;

    public int multiplier1 = 1;
    public int multiplier2 = 2;
    public int multiplier3 = 3;
    public int multiplier4 = 4;
    public int multiplier5 = 5;

    public static PlayerScore _instance;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(this.gameObject);
        }
        else {
            _instance = this;
        }
    }


    void Update()
    {
        switch (hitCount)
        {
            case 0:
                currentMultiplier = multiplier1;
                break;
            case hitStreak1:
                currentMultiplier = multiplier2;
                break;
            case hitStreak2:
                currentMultiplier = multiplier3;
                break;
            case hitStreak3:
                currentMultiplier = multiplier4;
                break;
            case hitStreak4:
                currentMultiplier = multiplier5;
                break;
        }

		if (SceneManagement.currentSceneIndex == 4 && currentScore > HighScore1) 
		{
			HighScore1 = currentScore;
			PlayerPrefs.SetInt ("TopScore1", HighScore1);
		}
		if (SceneManagement.currentSceneIndex == 5 && currentScore > HighScore2) 
		{
			HighScore2 = currentScore;
			PlayerPrefs.SetInt ("TopScore2", HighScore2);
		}
		if (SceneManagement.currentSceneIndex == 6 && currentScore > HighScore3) 
		{
			HighScore3 = currentScore;
			PlayerPrefs.SetInt ("TopScore3", HighScore3);
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
        hitCount += _hitCount;
        //switch over the note hitCount and set the appropriate multiplier


        //update currentScore with the rewarded score and the updated multiplier
        currentScore += _score * currentMultiplier;
    }
}

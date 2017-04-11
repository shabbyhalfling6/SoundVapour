using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	public static GameObject UpperDialSelect;
	public static GameObject BottomDialSelect;
	public static GameObject LeftDialSelect;
	public static GameObject RightDialSelect;
	public Text ScoreText;
	public Text MultiplierText;

	void Awake()
	{
		UpperDialSelect = GameObject.Find ("UpperSelect");
		BottomDialSelect = GameObject.Find ("BottomSelect");
		LeftDialSelect = GameObject.Find ("LeftSelect");
		RightDialSelect = GameObject.Find ("RightSelect");
	}

	void Update()
	{
		ScoreText.text = "Score: " + PlayerScore.Instance.currentScore.ToString ();
		MultiplierText.text = "Mulitplier: " + PlayerScore.Instance.currentMultiplier.ToString ();
	}
    //PlayerScore.Instance.currentScore... 
    //PlayerScore.Instance.curentMultiplier...
    //to get the current player score and multiplier

    //GameController.Instance.win...
    //GameController.Instance.lose...
    //to get the current win and lose state
}

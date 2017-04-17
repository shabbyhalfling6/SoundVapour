using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuDial : SceneManagement {

	public static GameObject UpperDialSelect;
	public static GameObject BottomDialSelect;
	public static GameObject LeftDialSelect;
	public static GameObject RightDialSelect;
	public string selectedOption;
	private float horizontalDialSelection;
	private float verticalDialSelection;
	private Color selectedColor = Color.white;
	private Color deselectedColor = Color.clear;

	void Awake()
	{
	/*+++++++++++++++++++++++++++++++++++++
	 * ASSIGNS DIAL SECTIONS TO BUTTONS
	 ++++++++++++++++++++++++++++++++++++++*/
		UpperDialSelect = GameObject.Find ("PlayButton");
		BottomDialSelect = GameObject.Find ("QuitButton");
		LeftDialSelect = GameObject.Find ("OptionsButton");
		RightDialSelect = GameObject.Find ("CreditsButton");
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	/*+++++++++++++++++++++++++++++++++++++
	 * CONTROLLER SUPPORT FOR MENU
	 ++++++++++++++++++++++++++++++++++++++*/
		horizontalDialSelection = Input.GetAxis("Horizontal");
		verticalDialSelection = Input.GetAxis("Vertical");

		if (horizontalDialSelection < 0)
		{
			SelectOptions ();
		}
		else if (horizontalDialSelection > 0)
		{
			SelectCredits ();
		}
		else if (verticalDialSelection < 0)
		{
			SelectQuit ();
		}
		else if (verticalDialSelection > 0)
		{
			SelectPlay ();
		}
		else
		{
			SelectNothing ();
		}

		if(selectedOption == "Play" && Input.GetButtonUp("Vapourise"))
		{
			LoadGameScene();
		}
		if(selectedOption == "Options" && Input.GetButtonUp("Vapourise"))
		{
			LoadOptionsScene();
		}
		if(selectedOption == "Credits" && Input.GetButtonUp("Vapourise"))
		{
			LoadCreditsScene();
		}
		if(selectedOption == "Quit" && Input.GetButtonUp("Vapourise"))
		{
			QuitGame();
		}
	}

	/*+++++++++++++++++++++++++++++++++++++
	 * MENU SELECTION WORKS HERE BY CHANGING THE ALPHA
	 * CHANNEL OF EACH BUTTON UI IMAGE TO WHITE, THEN
	 * SELECTING CLEAR WHEN A BUTTON IS NO LONGER SELECTED.
	 ++++++++++++++++++++++++++++++++++++++*/
	public void SelectOptions()
	{
		selectedOption = "Options";
		LeftDialSelect.GetComponent<Image> ().color = selectedColor;
		RightDialSelect.GetComponent<Image> ().color = deselectedColor;
		UpperDialSelect.GetComponent<Image> ().color = deselectedColor;
		BottomDialSelect.GetComponent<Image> ().color = deselectedColor;
	}
	public void SelectCredits()
	{
		selectedOption = "Credits";
		LeftDialSelect.GetComponent<Image> ().color = deselectedColor;
		RightDialSelect.GetComponent<Image> ().color = selectedColor;
		UpperDialSelect.GetComponent<Image> ().color = deselectedColor;
		BottomDialSelect.GetComponent<Image> ().color = deselectedColor;
	}
	public void SelectPlay()
	{
		selectedOption = "Play";
		LeftDialSelect.GetComponent<Image> ().color = deselectedColor;
		RightDialSelect.GetComponent<Image> ().color = deselectedColor;
		UpperDialSelect.GetComponent<Image> ().color = selectedColor;
		BottomDialSelect.GetComponent<Image> ().color = deselectedColor;
	}
	public void SelectQuit()
	{
		selectedOption = "Quit";
		LeftDialSelect.GetComponent<Image> ().color = deselectedColor;
		RightDialSelect.GetComponent<Image> ().color = deselectedColor;
		UpperDialSelect.GetComponent<Image> ().color = deselectedColor;
		BottomDialSelect.GetComponent<Image> ().color = selectedColor;
	}
	public void SelectNothing()
	{
		selectedOption = null;
		LeftDialSelect.GetComponent<Image> ().color = deselectedColor;
		RightDialSelect.GetComponent<Image> ().color = deselectedColor;
		UpperDialSelect.GetComponent<Image> ().color = deselectedColor;
		BottomDialSelect.GetComponent<Image> ().color = deselectedColor;
	}
}

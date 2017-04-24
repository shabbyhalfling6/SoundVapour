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
	public Vector2 inputVector;

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

		inputVector.x = horizontalDialSelection;
		inputVector.y = verticalDialSelection;
		inputVector.Normalize ();

		float vectorMagnitude = 0.7f;

		if ((inputVector.x <= -vectorMagnitude))
		{
			SelectOptions ();
		}
		else if ((inputVector.x >= vectorMagnitude))
		{
			SelectCredits ();
		}
		else if ((inputVector.y <= -vectorMagnitude))
		{
			SelectQuit ();
		}
		else if ((inputVector.y >= vectorMagnitude))
		{
			SelectPlay ();
		}
		else
		{
			SelectNothing ();
		}

		if(selectedOption == "Play" && Input.GetButtonUp("Vapourise"))
		{
			LoadSongSelectScene();
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

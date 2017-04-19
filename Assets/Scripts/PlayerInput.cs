using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerInput : MonoBehaviour
{
	public string selectedShape;
    private float horizontalDialSelection;
    private float verticalDialSelection;
	private int standardScore = 20;
	private GameObject pauseMenu;
    private Animator anim;
	public static bool isPaused = false;
    private bool destroyedShape = false;
	void Start()
	{
        anim = this.GetComponentInChildren<Animator>();
		pauseMenu = GameObject.Find ("PauseMenu");
		pauseMenu.SetActive (false);
	}

    void Update()
    {
        anim.SetBool("Vapourise", false);

        horizontalDialSelection = Input.GetAxis("Horizontal");
        verticalDialSelection = Input.GetAxis("Vertical");

        if(Input.GetButtonDown("Vapourise"))
        {
            anim.SetBool("Vapourise", true);
        }

		//Dial selection is nested under isPaused bool to prevent the dial selection from occuring in the pause menu
		if (isPaused == false && UIController.inst != null ) 
		{
			if (horizontalDialSelection < 0)
			{
				selectedShape = "Square";
				UIController.inst.LeftDialSelect.SetActive(true);
				UIController.inst.RightDialSelect.SetActive(false);
				UIController.inst.UpperDialSelect.SetActive(false);
				UIController.inst.BottomDialSelect.SetActive(false);
			}
			else if (horizontalDialSelection > 0)
			{
				selectedShape = "Circle";
				UIController.inst.RightDialSelect.SetActive(true);
				UIController.inst.UpperDialSelect.SetActive(false);
				UIController.inst.LeftDialSelect.SetActive(false);
				UIController.inst.BottomDialSelect.SetActive(false);
			}
			else if (verticalDialSelection < 0)
			{
				selectedShape = "X";
				UIController.inst.BottomDialSelect.SetActive(true);
				UIController.inst.UpperDialSelect.SetActive(false);
				UIController.inst.LeftDialSelect.SetActive(false);
				UIController.inst.RightDialSelect.SetActive(false);
			}
			else if (verticalDialSelection > 0)
			{
				selectedShape = "Triangle";
				UIController.inst.UpperDialSelect.SetActive(true);
				UIController.inst.LeftDialSelect.SetActive(false);
				UIController.inst.RightDialSelect.SetActive(false);
				UIController.inst.BottomDialSelect.SetActive(false);
			}
			else
			{
				selectedShape = string.Empty;
				UIController.inst.LeftDialSelect.SetActive(false);
				UIController.inst.RightDialSelect.SetActive(false);
				UIController.inst.BottomDialSelect.SetActive(false);
				UIController.inst.UpperDialSelect.SetActive(false);
			}
		}

        if (Input.GetButtonDown("Vapourise") && !destroyedShape)
        {
            PlayerScore.Instance.hitCount = 0;
        }

		//If player hits the pause button, it activates the menu and pauses gameplay.
		if (Input.GetButtonDown("Pause"))
		{
			pauseToggle ();
		}
        destroyedShape = false;
    }

	public void pauseToggle()
	{
		pauseMenu.SetActive(!pauseMenu.activeInHierarchy);
		Debug.Log("Pause Button Hit");
		if (pauseMenu.activeInHierarchy) 
		{
			Time.timeScale = 0;
			isPaused = true;
		} 
		else 
		{
			Time.timeScale = 1;
			isPaused = false;
		}
	}

    void OnTriggerExit2D(Collider2D other)
    { 
        other.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        other.gameObject.GetComponent<ShapeMoveController>().enabled = false;
        other.gameObject.tag = "Shape";
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if(Input.GetAxisRaw("Vapourise") == 0)
        {
            return;
        }
        
        //if the shape passing the line is the selected shape and you press the vapourise button...
        if (collider.gameObject.tag == selectedShape)
        {
            //destroy the shape
            Destroy(collider.gameObject);

            destroyedShape = true;
            //NOTE: temporary score setting, replace with detecting perfects and goods
            int score = standardScore;
            //call the RewardScore function in the PlayerScore class to update the currentScore
            PlayerScore.Instance.RewardScore(1, score);
        }
    }
}

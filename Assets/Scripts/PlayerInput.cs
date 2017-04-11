using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerInput : MonoBehaviour
{
	public string selectedShape;
    public ParticleSystem laserFire;
    private float horizontalDialSelection;
    private float verticalDialSelection;

    private int hitCount = 0;

    private int standardScore = 20;

    void Update()
    {
        horizontalDialSelection = Input.GetAxis("Horizontal");
        verticalDialSelection = Input.GetAxis("Vertical");

		if (horizontalDialSelection < 0) 
		{
			selectedShape = "Square";
			UIController.LeftDialSelect.SetActive (true);
		} 
		else if (horizontalDialSelection > 0) 
		{
			selectedShape = "Circle";
			UIController.RightDialSelect.SetActive (true);
		} 
		else if (verticalDialSelection < 0) 
		{
			selectedShape = "X";
			UIController.BottomDialSelect.SetActive (true);
		} 
		else if (verticalDialSelection > 0) 
		{	
			selectedShape = "Triangle";
			UIController.UpperDialSelect.SetActive (true);
		} 
		else 
		{
			selectedShape = null;
			UIController.LeftDialSelect.SetActive (false);
			UIController.RightDialSelect.SetActive (false);
			UIController.BottomDialSelect.SetActive (false);
			UIController.UpperDialSelect.SetActive (false);
		}

        if (Input.GetButtonDown("Vapourise"))
        {
            laserFire.Play();
        }
        else
        {
            laserFire.Stop();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        collision.gameObject.GetComponent<ShapeMoveController>().enabled = false;
        collision.gameObject.tag = "Shape";
        PlayerScore.Instance.RewardScore(0, 0);
    }

    void OnTriggerStay2D(Collider2D collision)
    {

        //if the shape passing the line is the selected shape and you press the vapourise button...
        if (selectedShape == collision.gameObject.tag)
        {
            //and you press the vapourise button...
            if (Input.GetButtonDown("Vapourise"))
            {
                //destroy the shape
                Destroy(collision.gameObject);

                //increment the hitCount
                hitCount++;
                //NOTE: temporary score setting, replace with detecting perfects and goods
                int score = standardScore;
                //call the RewardScore function in the PlayerScore class to update the currentScore
                PlayerScore.Instance.RewardScore(hitCount, score);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerInput : MonoBehaviour
{
	public string selectedShape;
    public ParticleSystem laserFire;
    private float horizontalDialSelection;
    private float verticalDialSelection;

    private int standardScore = 20;

    void Update()
    {
        horizontalDialSelection = Input.GetAxis("Horizontal");
        verticalDialSelection = Input.GetAxis("Vertical");

        if (horizontalDialSelection < 0)
        {
            selectedShape = "Square";
            UIController.LeftDialSelect.SetActive(true);
            UIController.RightDialSelect.SetActive(false);
            UIController.UpperDialSelect.SetActive(false);
            UIController.BottomDialSelect.SetActive(false);
        }
        else if (horizontalDialSelection > 0)
        {
            selectedShape = "Circle";
            UIController.RightDialSelect.SetActive(true);
            UIController.UpperDialSelect.SetActive(false);
            UIController.LeftDialSelect.SetActive(false);
            UIController.BottomDialSelect.SetActive(false);
        }
        else if (verticalDialSelection < 0)
        {
            selectedShape = "X";
            UIController.BottomDialSelect.SetActive(true);
            UIController.UpperDialSelect.SetActive(false);
            UIController.LeftDialSelect.SetActive(false);
            UIController.RightDialSelect.SetActive(false);
        }
        else if (verticalDialSelection > 0)
        {
            selectedShape = "Triangle";
            UIController.UpperDialSelect.SetActive(true);
            UIController.LeftDialSelect.SetActive(false);
            UIController.RightDialSelect.SetActive(false);
            UIController.BottomDialSelect.SetActive(false);
        }
        else
        {
            selectedShape = null;
            UIController.LeftDialSelect.SetActive(false);
            UIController.RightDialSelect.SetActive(false);
            UIController.BottomDialSelect.SetActive(false);
            UIController.UpperDialSelect.SetActive(false);
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
    }

    void OnTriggerStay2D(Collider2D collision)
    {

        //if the shape passing the line is the selected shape and you press the vapourise button...
        if (selectedShape == collision.gameObject.tag && Input.GetButtonDown("Vapourise"))
        {
            //destroy the shape
            Destroy(collision.gameObject);

            //NOTE: temporary score setting, replace with detecting perfects and goods
            int score = standardScore;
            //call the RewardScore function in the PlayerScore class to update the currentScore
            PlayerScore.Instance.RewardScore(1, score);
        }
    }
}

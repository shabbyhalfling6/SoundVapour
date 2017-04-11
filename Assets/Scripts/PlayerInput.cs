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
            selectedShape = "Square";
        else if (horizontalDialSelection > 0)
            selectedShape = "Circle";
        else if (verticalDialSelection < 0)
            selectedShape = "X";
        else if (verticalDialSelection > 0)
            selectedShape = "Triangle";
        else
            selectedShape = null;

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerInput : MonoBehaviour {

    public string selectedShape;

    private float horizontalDialSelection;
    private float verticalDialSelection;




    void Update ()
    {
        horizontalDialSelection = Input.GetAxis("Horizontal");
        verticalDialSelection = Input.GetAxis("Vertical");

        if (horizontalDialSelection < 0)
            selectedShape = "Square";
        else if (horizontalDialSelection > 0)
            selectedShape = "Circle";
        if (verticalDialSelection < 0)
            selectedShape = "X";
        else if (verticalDialSelection > 0)
            selectedShape = "Triangle";
	}

    void OnTriggerStay2D(Collider2D collision)
    {
        //if the shape passing the line is the selected shape and you press the vapourise button...
        if(selectedShape == collision.gameObject.tag)
        {
            Debug.Log("Collision detected: " + collision.tag);
            //and you press the vapourise button...
            if(Input.GetKeyDown(KeyCode.Space))
            {
                //destroy the shape
                Destroy(collision.gameObject);
            }
        }
    }
}

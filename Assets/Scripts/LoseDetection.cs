using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseDetection : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Shape" && gameObject.tag == "Circle" || gameObject.tag == "Square" || gameObject.tag == "X" || gameObject.tag == "Triangle")
		{
			GameController.Instance.lose = true;
			Debug.Log ("game should end");
		}
	}
}

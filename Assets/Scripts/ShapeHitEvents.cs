using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeHitEvents : MonoBehaviour {

	void OnParticleCollision (GameObject shape)
	{
		if (PlayerInput.selectedShape == shape.gameObject.tag) 
		{
			Debug.Log("Collision detected: " + shape.tag);
			Destroy(shape.gameObject);
		}
	}
}

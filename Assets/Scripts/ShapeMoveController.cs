using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeMoveController : MonoBehaviour {

    private float shapeMoveSpeed = 3.5f;

	void FixedUpdate ()
    {
        transform.Translate(Vector3.down * Time.deltaTime * shapeMoveSpeed);	
	}
}

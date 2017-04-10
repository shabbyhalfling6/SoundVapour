using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeDestoyer : MonoBehaviour {

    //destroy anything that triggers with this
    void OnTriggerEnter2D(Collider2D collider)
    {
        Destroy(collider.gameObject);
    }
}

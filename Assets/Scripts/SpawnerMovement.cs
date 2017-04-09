using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerMovement : MonoBehaviour {
    //recieved from http://answers.unity3d.com/questions/754633/how-to-move-an-object-left-and-righ-looping.html

    private float moveArea = 7.0f;  // Amount to move left and right from the start point
    public float moveSpeed = 2.0f;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        Vector3 v = startPos;
        v.x += moveArea * Mathf.Sin(Time.time * moveSpeed);
        transform.position = v;
    }
}

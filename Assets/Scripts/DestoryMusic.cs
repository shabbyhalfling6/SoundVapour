using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryMusic : MonoBehaviour {

    // Use this for initialization
    void Awake()
    {
        GameObject objs = GameObject.FindGameObjectWithTag("music");
        Destroy(objs);
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PypeManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnBecameVisible()
    {
        this.GetComponent<Renderer>().enabled = true;
    }

    void OnBecameInvisible()
    {
        this.GetComponent<Renderer>().enabled = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPypeManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "DestroyPypeZone")
        {
            GameObject gameManager = GameObject.Find("GameManager");
            gameManager.GetComponent<GameManager>().DestroyPype();
        }
    }
}

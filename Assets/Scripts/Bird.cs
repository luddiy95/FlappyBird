using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

    public static bool deathzoneCol;

	// Use this for initialization
	void Start () {
        deathzoneCol = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Fly()
    {
        if(deathzoneCol == false)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 1f);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "deathzone")
        {
            deathzoneCol = true;
            this.GetComponent<Rigidbody2D>().isKinematic = true;
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "PypePathZone")
        {
            ++GameManager.myRecord;
        }
    }
}






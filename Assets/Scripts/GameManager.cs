using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject Pype;
    const int PypesNm = 10;
    const float PypeInterval = 0.8f;
    Queue<GameObject> Pypes = new Queue<GameObject>();

    public GameObject GameOver;

    public static int myRecord;
    public GameObject TextMyRecord;
    public GameObject TextBestRecord;

	// Use this for initialization
	void Start () {
		for(int i = 0; i < PypesNm; i++)
        {
            int r = Random.Range(0, 9);
            float y = -0.4f + (float)r / 10f;
            float x = 2f + PypeInterval * (float)i;
            Pypes.Enqueue(Instantiate(Pype, new Vector3(x, y, 0f), Quaternion.identity));
        }
        myRecord = 0;
        if(PlayerPrefs.GetInt("BestRecord") > 0)
        {

        }
        else
        {
            PlayerPrefs.SetInt("BestRecord", 0);
        }
        TextBestRecord.GetComponent<Text>().text = "BestRecord: " + PlayerPrefs.GetInt("BestRecord");
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Bird.deathzoneCol == false)
        {
            foreach (GameObject pype in Pypes)
            {
                pype.transform.position += new Vector3(-0.01f, 0f, 0f);
            }
            TextMyRecord.GetComponent<Text>().text = "MyRecord: " + myRecord;
        }
        else
        {
            GameOver.SetActive(true);
            if(myRecord > PlayerPrefs.GetInt("BestRecord"))
            {
                PlayerPrefs.SetInt("BestRecord", myRecord);
                TextBestRecord.GetComponent<Text>().text = "BestRecord: " + myRecord;
            }
        }
	}

    public void DestroyPype()
    {
        float headX = Pypes.Peek().transform.position.x;
        Destroy(Pypes.Dequeue());
        float tailX = headX + PypeInterval * (PypesNm - 1);
        int r = Random.Range(0, 9);
        float ty = -0.4f + (float)r / 10f;
        Pypes.Enqueue(Instantiate(Pype, new Vector3(tailX + PypeInterval, ty, 0f), Quaternion.identity));
    }


    public void ReTry()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}

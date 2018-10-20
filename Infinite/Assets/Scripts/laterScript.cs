using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laterScript : MonoBehaviour {

    gameManager gm;
    public GameObject pepperSpawn;

    // Use this for initialization
    void Start () {
        gm = GameObject.Find("GameManager").GetComponent<gameManager>();
    }
	
	// Update is called once per frame
	void Update () {
        if (gm.getScore() >= 25)
        {
            pepperSpawn.GetComponent<spawnScript>().enabled = true;
        }
    }
}

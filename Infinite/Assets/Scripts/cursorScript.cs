using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 temp = Input.mousePosition;
        temp.z = 10f; // Distance infront of camera
        this.transform.position = Camera.main.ScreenToWorldPoint(temp);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformMovement : MonoBehaviour {

	public float moveSpeed;
	private Vector3 move = new Vector3();

	// Use this for initialization
	void Start () {
        //Change values to change direction
		move.x = -moveSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate(move * Time.deltaTime);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnScript : MonoBehaviour {

    // Used for spawning
    public GameObject[] obj;
    public GameObject spawner;
    // Spawn between 1-2 seconds
    public float spawnMin;
    public float spawnMax;

    // Used for Movement
    public float moveSpeed = 5;
    public Transform currentPoint;
    public Transform[] point;
    public int pointSelected;

	// Use this for initialization
	void Start () {
        currentPoint = point[pointSelected];
        Spawn();
	}

    void Update()
    {
        //Move towards positions in point[] array then reset when last element reached
        spawner.transform.position = Vector3.MoveTowards(spawner.transform.position, currentPoint.position, Time.deltaTime * moveSpeed);
        if(spawner.transform.position == currentPoint.position)
        {
            pointSelected++;
            if(pointSelected == point.Length)
            {
                pointSelected = 0;
            }
            currentPoint = point[pointSelected];
        }
    }
    
    void Spawn()
    {
        //Spawns an object from the array within the time of spawnMin and spawnMax
        Instantiate(obj[Random.Range(0, obj.Length)], transform.position, Quaternion.identity);
        Invoke("Spawn", Random.Range(spawnMin, spawnMax));
    }
}

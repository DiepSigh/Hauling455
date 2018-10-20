using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recycleScript : MonoBehaviour {
    // Destroys object and parents object on collision
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "Player")
        {
            if (other.gameObject.transform.parent)
            {
                Destroy(other.gameObject.transform.parent.gameObject);
            }
            else
            {
                Destroy(other.gameObject);
            }
        }
    }

}
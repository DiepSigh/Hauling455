using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Requires sprite renderer component
[RequireComponent(typeof(SpriteRenderer))]
public class shadowScript : MonoBehaviour {

    public Vector3 Offset = new Vector3(-0.1f, -0.1f);
    public Material Material;
    GameObject shadow;

	// Use this for initialization
	void Start () {
        //Make object that shadows its parent's transform
        shadow = new GameObject("Shadow");
        shadow.transform.parent = transform;

        //Get parent's transform data
        shadow.transform.localPosition = Offset;
        shadow.transform.localRotation = Quaternion.identity;

        //Render shadow sprite
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        SpriteRenderer sr = shadow.AddComponent<SpriteRenderer>();
        sr.sprite = renderer.sprite;

        sr.material = Material;

        //Rendered shadow should be behind parent
        sr.sortingLayerName = renderer.sortingLayerName;
        sr.sortingOrder = renderer.sortingOrder = 1;
	}

    void LateUpdate()
    {
        //Maintain its position
        shadow.transform.localPosition = Offset;
    }

}

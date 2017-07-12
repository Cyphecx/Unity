using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManyCubes : MonoBehaviour {
	public GameObject Object;
	Rigidbody rifig;
	// Use this for initialization
	void Start () {
		
	}

	void Update () {
		
		Object = Instantiate (Object);
		/*
		rifig = Object.GetComponent<Rigidbody> ();
		rifig.velocity = new Vector3 (Random.Range(0F,3F), Random.Range(0F,3F), Random.Range(0F,3F));
		*/
	}
}

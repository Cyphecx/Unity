using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brob : MonoBehaviour {
	Rigidbody2D brobRigid;
	float health = 100;
	// Use this for initialization
	void Start () {
		brobRigid = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(health <= 0){
			Destroy (gameObject);
		}
	}
	void OnCollisionEnter2D(Collision2D col){
		health -= col.relativeVelocity.magnitude;
	}
}

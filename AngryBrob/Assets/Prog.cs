using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prog : MonoBehaviour {
	float health;
	// Use this for initialization
	void Start () {
		health = 10;
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0F) {
			Destroy (gameObject);
		}
	}
	void OnCollisionEnter2D(Collision2D col){
		health -= col.relativeVelocity.magnitude;
	}
}

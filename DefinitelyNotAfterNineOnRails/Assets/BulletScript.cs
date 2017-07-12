using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {
	public float velocity;
	float dist;
	float topBorder;
	float bottomBorder;

	void Start () {
		dist = (transform.position - Camera.main.transform.position).z;
		topBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0F, 1F, dist)).y;
		bottomBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0F, 0F, dist)).y;
	}
	void Update () {
		transform.position = new Vector3 (transform.position.x, transform.position.y + velocity, 40);
		if(transform.position.y > topBorder){
			Destroy (gameObject);
		}
	}
}

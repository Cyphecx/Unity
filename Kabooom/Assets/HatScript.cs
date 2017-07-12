using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatScript : MonoBehaviour {
	static int hat = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float dist = (transform.position - Camera.main.transform.position).z;
		if (transform.position.y < Camera.main.ViewportToWorldPoint (new Vector3(0F, 0F, dist)).y) {
			hat++;
			print (hat);
			Destroy (GameObject.FindGameObjectWithTag("Hand" + hat));
			if (hat == 3) {
				print ("Boom");
			}
			foreach (GameObject o in GameObject.FindGameObjectsWithTag("Hat")) {
				Destroy (o);
			}
		}
			
	}
}

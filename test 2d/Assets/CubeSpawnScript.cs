using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawnScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy (gameObject,2F);
		transform.position = new Vector3 (Random.Range(-10F, 10F), Random.Range(-10F, 10F), Random.Range(-10F, 10F));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

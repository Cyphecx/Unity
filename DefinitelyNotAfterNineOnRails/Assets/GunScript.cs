using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour {
	public GameObject bullet;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void shoot(){
		GameObject obj;
		obj = Instantiate (bullet);
		obj.transform.position = transform.GetChild(0).position;
	}
}

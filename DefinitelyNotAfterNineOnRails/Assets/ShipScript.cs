using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipScript : MonoBehaviour {
	float xAxis;
	float yAxis;
	float dist;
	float time;
	public float leftBorder;
	public float rightBorder;
	float topBorder;
	float bottomBorder;
	bool shooting;

	void Start () {
		time = Time.time;
		shooting = false;
		xAxis = 0;
		yAxis = 0;
		dist = (transform.position - Camera.main.transform.position).z;
		topBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0F, 1F, dist)).y - 250;
		bottomBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0F, 0F, dist)).y + 70;
	}
		
	void Update () {
		if(shooting && Time.time - time > 0.1F){
			for(int i = 0; i < gameObject.transform.childCount; i++){
				gameObject.transform.GetChild(i).GetComponent<GunScript>().shoot ();	
			}
			time = Time.time;
		}
		yAxis = Input.GetAxis ("Vertical");
		xAxis = Input.GetAxis ("Horizontal");

		transform.position = new Vector3(transform.position.x + ((xAxis * 5000F) * Time.deltaTime) , transform.position.y + ((yAxis * 5000F) * Time.deltaTime), 40F);
		if(transform.position.x > rightBorder){
			transform.position = new Vector3 (rightBorder, transform.position.y, 40F);
		}
		if(transform.position.x < leftBorder){
			transform.position = new Vector3 (leftBorder, transform.position.y, 40F);
		}
		if(transform.position.y > topBorder){
			transform.position = new Vector3 (transform.position.x, topBorder, 40F);
		}
		if(transform.position.y < bottomBorder){
			transform.position = new Vector3 (transform.position.x, bottomBorder, 40F);
		}
		if (Input.GetKey (KeyCode.Space)) {
			shooting = true;
		} else {
			shooting = false;
		}
	}
}

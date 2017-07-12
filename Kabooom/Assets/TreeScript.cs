using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class TreeScript : MonoBehaviour {
	public GameObject ject;
	bool right;
	bool left;
	float velocity;
	float time;
	float rTime;
	public GameObject Scire;
	Text ui;
	int score;
	// Use this for initialization
	void Start () {
		print ("thing");
		right = false;
		left = true;
		rTime = 0;
		time = 0;
		score = 0;
		Scire.GetComponent<Text> ().text = "Score: 0";


	}
	
	// Update is called once per frame
	void Update () { 
		float dist = (transform.position - Camera.main.transform.position).z;
		float leftBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0F, 0F, dist)).x;
		float rightBorder = Camera.main.ViewportToWorldPoint (new Vector3 (1F, 0F, dist)).x;
		float change = UnityEngine.Random.Range (0F, 1F);
		if (change < 0.03F && Time.time - time > 0.5F) {
			left = !left;
			right = !right;
			time = Time.time;
		}
		if (left) {
			velocity = -5F;
		}
		if (right) {
			velocity = 5F;
		}
		if (transform.position.x + (transform.localScale.x / 2) < leftBorder) {
			velocity = 5F;
			left = false;
			right = true;
			time = Time.time;
		}
		if (transform.position.x - (transform.localScale.x / 2) > rightBorder) {
			left = true;
			right = false;
			velocity = -5F;
			time = Time.time;
		}
		transform.position = new Vector2 (transform.position.x + (velocity * Time.deltaTime), transform.position.y);
		if (Time.time - rTime > 0.75F) {
			ject = Instantiate (ject);
			ject.transform.position = transform.position;
			rTime = Time.time;
		}
	}
	public void increaseScore(){
		if (Scire == null) {
			print ("All of my hate");
			Scire = GameObject.FindGameObjectWithTag ("Score");
		}


		ui = Scire.GetComponent<Text> ();
		score = Int32.Parse (ui.text.Substring (6));
		score++;
		ui.text = "Score: " + score;
	}
}

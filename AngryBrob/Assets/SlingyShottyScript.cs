using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlingyShottyScript : MonoBehaviour {
	Vector3 offset;
	Transform halo;
	bool brobHeld;
	GameObject brob;
	public GameObject marker;
	Vector3 mousePos;
	Rigidbody2D brobRigid;
	// Use this for initialization
	void Start () {
		halo = transform.GetChild (0);
		mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		brob = GameObject.FindGameObjectWithTag ("Brob");
		brobRigid = brob.GetComponent<Rigidbody2D> ();
		brobHeld = false;
		offset = mousePos - halo.transform.position;
		print (brob);
	}
	
	// Update is called once per frame
	void Update () {
		if(brob == null){
			if (GameObject.FindGameObjectWithTag ("Brob") == null) {
				EndGame ();

			} else {
				brob = GameObject.FindGameObjectWithTag ("Brob");
				brobRigid = brob.GetComponent<Rigidbody2D> ();

			}
		}
		mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		mousePos.z = 0;
		halo.transform.position = new Vector3 (halo.transform.position.x, halo.transform.position.y, 0F);
		offset = mousePos - halo.transform.position;

		if (brobHeld){
			//print ((mousePos - halo.position).magnitude);
			if (offset.magnitude > 2F) {
				//brob.transform.position = (((mousePos - halo.position) / (mousePos.magnitude))) * 2F + halo.position;
				offset=offset.normalized*2f;
			}
			brob.transform.position = halo.position + offset;
		}
	}
	void OnMouseEnter(){
		transform.GetChild (0).gameObject.SetActive (true);
	}
	void OnMouseExit(){
		transform.GetChild (0).gameObject.SetActive (false);
	}
	void OnMouseDown(){
		brobHeld = true;
		brobRigid.gravityScale = 0;
		brobRigid.simulated = false;
	} 
	void OnMouseUp(){
		brobHeld = false;
		brobRigid.gravityScale = 1;
		brobRigid.simulated = true;
		launchBrob();
	}
	void launchBrob(){
		brobRigid.velocity = Vector3.zero - (offset*15);
		//brobRigid.angu
	}
	void EndGame(){
		SceneManager.LoadScene ("GameOver");
	}
}

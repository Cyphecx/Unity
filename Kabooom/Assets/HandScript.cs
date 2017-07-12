using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandScript : MonoBehaviour {
	float input;
	public GameObject treeS;
	TreeScript TS;
	// Use this for initialization
	void Start () {
		TS = treeS.GetComponent<TreeScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		float dist = (transform.position - Camera.main.transform.position).z;
		float leftBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0F, 0F, dist)).x;
		float rightBorder = Camera.main.ViewportToWorldPoint (new Vector3 (1F, 0F, dist)).x;
		input = Input.GetAxis ("Horizontal");
		if(!(input < 0F && transform.position.x-(transform.localScale.x/2) < leftBorder) && !(input > 0F && transform.position.x+(transform.localScale.x/2) > rightBorder)){
			transform.position = new Vector2(transform.position.x + ((input*10)*Time.deltaTime), transform.position.y);
		}
	}
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Hat") {
			TS.increaseScore ();
			Destroy (col.gameObject);
		}
	}
}

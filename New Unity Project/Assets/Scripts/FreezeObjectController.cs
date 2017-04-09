using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeObjectController : MonoBehaviour {

	// Use this for initialization
	private bool breaking;
	private int eatfood;
	private GameObject Eater;
	public GameObject X_button;
	void Start () {
		breaking = false;
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		if (eatfood > 0) {
			gameObject.transform.position = Vector3.MoveTowards (transform.position, Eater.gameObject.transform.position, 5.5f * Time.deltaTime);
			gameObject.transform.localScale -= Vector3.one * 5.5f * Time.deltaTime;
			if (++eatfood == 40) {
				Destroy (this.gameObject);
			}
		}
	}
	void FixedUpdate(){
		if (breaking && Input.GetKeyDown (KeyCode.X) && name == "Blocker") {
			gameObject.GetComponent<BoxCollider> ().enabled = false;
			eatfood = 1;
		}
	}
	void OnCollisionStay(Collision c){
		if (c.gameObject.name == "ChubbyBoy" && c.gameObject.transform.localScale.x >5.0f) {
			X_button.SetActive (true);
			breaking = true;
			Eater = c.gameObject;
		}
	}
	void OnCollisionExit(Collision c){
		if (c.gameObject.name == "ChubbyBoy") {
			X_button.SetActive (false);
			breaking = false;
		}
	}
}

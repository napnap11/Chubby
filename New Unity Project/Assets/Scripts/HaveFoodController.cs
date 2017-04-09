using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaveFoodController : MonoBehaviour {

	// Use this for initialization
	public GameObject X_button;
	public GameObject[] Foods;
	private GameObject Eater;
	public int numFood;
	public int Type;
	public GameObject powerUp;
	private int TotalFood;
	private bool eating;
	private int[] eatfood;
	private bool burnt;
	private AudioSource audio;
	void Start () {
		eating = false;
		eatfood = new int[numFood];
		TotalFood = numFood;
		burnt = false;
		audio = gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Type == 0) {
			for (int i = 0; i < TotalFood; i++) {
				if (eatfood [i] > 0) {
					if (!audio.isPlaying)
						audio.Play ();
					Foods [i].gameObject.transform.position = Vector3.MoveTowards (Foods [i].transform.position, Eater.gameObject.transform.position, 5.5f * Time.deltaTime);
					eatfood [i]++;

					if (eatfood [i] == 40) {
						Destroy (Foods [i].gameObject);
						eatfood [i] = 0;
						TotalFood--;
						PlayerPrefs.SetInt ("Score", PlayerPrefs.GetInt ("Score", 0) + 1);
					}
				}
			}
		}
		if (Type == 1 || Type == 3) {
			if (eatfood [0] > 0) {

				if (!audio.isPlaying)
					audio.Play ();
				gameObject.transform.position = Vector3.MoveTowards (transform.position, Eater.gameObject.transform.position, 5.5f * Time.deltaTime);
				gameObject.transform.localScale -= gameObject.transform.localScale * 5.5f * Time.deltaTime;
				if (++eatfood [0] == 40) {
					Destroy (this.gameObject);
					PlayerPrefs.SetInt ("Score", PlayerPrefs.GetInt ("Score", 0) + Type);
				}
			}
		}
	}
	void FixedUpdate(){
		if (eating && Input.GetKeyDown (KeyCode.X) && numFood >0) {
			numFood--;
			if(Type==0) eatfood [numFood] = 1;
			if (numFood <= 0) { 
				X_button.SetActive (false);
				if (Type == 1 || Type == 3) {
					gameObject.GetComponent<BoxCollider> ().enabled = false;
					eatfood [0] = 1;
				}
				if (Type == 2) {
					gameObject.GetComponent<BoxCollider> ().enabled = false;
					powerUp.SetActive (true);
					Destroy (gameObject);
				}
			}
		}
	}
	void OnCollisionEnter(Collision c){
		if (c.gameObject.tag == "Fireball" && Type == 3) {
			burnt = true;
			this.gameObject.GetComponent<SpriteRenderer> ().color = Color.red;
		}
	}
	void OnCollisionStay(Collision c){
		if (c.gameObject.name == "ChubbyBoy" && numFood > 0) {
			if (Type != 3 || burnt == true) {
				X_button.SetActive (true);
				eating = true;
				Eater = c.gameObject;
			}
		}
	}
	void OnCollisionExit(Collision c){
		if (c.gameObject.name == "ChubbyBoy") {
			X_button.SetActive (false);
			eating = false;
		}
	}
}

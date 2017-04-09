using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour {

	// Use this for initialization
	private int noPowerUp;
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other){
		string check = gameObject.name;
		Debug.Log (check);
		switch (check) {
		case "BiggerPowerUp":
			noPowerUp = PlayerPrefs.GetInt ("noPowerUp", 0);
			PlayerPrefs.SetString ("PowerUp" + noPowerUp, "Bigger");
			PlayerPrefs.SetInt ("noPowerUp", ++noPowerUp);
			PlayerPrefs.Save ();
			break;
		case "FirePowerUp":
			noPowerUp = PlayerPrefs.GetInt ("noPowerUp", 0);
			PlayerPrefs.SetString ("PowerUp" + noPowerUp, "Fire");
			PlayerPrefs.SetInt ("noPowerUp", ++noPowerUp);
			PlayerPrefs.Save ();
			break;
		}
		Destroy (gameObject);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballController : MonoBehaviour {

	// Use this for initialization
	float t;
	void Start () {
		t = Time.time;
	}

	// Update is called once per frame
	void Update () {
		if (Time.time > t + 0.6)
			Destroy (this.gameObject);
	}
}

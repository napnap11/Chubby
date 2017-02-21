using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChubbyController : MonoBehaviour {

	// Use this for initializatio
	float speed;
	void Start () {
		speed = 5f;
	}
	
	// Update is called once per frame
	void Update () {
		float x = Input.GetAxis ("Horizontal");
		float z = Input.GetAxis ("Vertical");
		float xx = x / Mathf.Sqrt(x * x + z * z);
		float zz = z / Mathf.Sqrt(x * x + z * z);
		transform.Translate (speed*xx*Time.deltaTime,0,speed*zz*Time.deltaTime);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	// Use this for initialization
	public GameObject player;

	private Vector3 offset;
	void Start () {
		offset = new Vector3(player.transform.position.x,player.transform.position.y,player.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void FixedUpdate(){
		transform.Translate(new Vector3(player.transform.position.x-offset.x,player.transform.position.y-offset.y,player.transform.position.z-offset.z),Space.World);
		offset = new Vector3(player.transform.position.x,player.transform.position.y,player.transform.position.z);
	}
}

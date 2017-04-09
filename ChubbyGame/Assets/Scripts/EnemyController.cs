using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	// Use this for initialization
	public enum status{normal,burn};
	public status myStatus;
	public Material[] myMaterial;
	public Rigidbody rb;
	void Start () {
		//myStatus = status.normal;
	}
	
	// Update is called once per frame
	void Update () {
		if (myStatus == status.burn) {
			float movex = Random.Range (-5, 5);
			float movez = Random.Range (-5, 5);
			rb.velocity = new Vector3((int)movex, 0, (int)movez);
		}
	}
	void OnTriggerEnter(Collider other){
		string type = other.gameObject.name;

		switch (type) {
		case "FireBolt":
			myStatus = status.burn;
			this.gameObject.GetComponent<MeshRenderer> ().material = myMaterial [1];
			break;
		default:
			break;
		}
	}
}

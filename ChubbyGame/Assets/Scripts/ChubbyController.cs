using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChubbyController : MonoBehaviour {

	// Use this for initializatio
	public enum Skill
	{
		Normal,Fire,Ice,Wind,Big,Small,Strong
	};
	public Skill mySkill;
	public GameObject Fireball;
	float speed;
	void Start () {
		//mySkill = Skill.Normal;
		speed = 5f;
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
		if (Input.GetKeyDown(KeyCode.X))
			DoSkill ();
	}
	void Move(){
		Vector3 move = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
		if (move != Vector3.zero) {
			transform.rotation = Quaternion.LookRotation (move);
		}
		//move = transform.TransformDirection (move);
		transform.Translate (move*speed*Time.deltaTime,Space.World);

	}
	void DoSkill(){
		switch (mySkill) {
		case Skill.Normal:
			break;
		case Skill.Fire:
			GameObject myfireball = Instantiate (Fireball, this.transform.position+transform.forward*0.01f, this.transform.rotation);
				myfireball.transform.rotation = transform.rotation;
				myfireball.GetComponent<Rigidbody> ().velocity = transform.forward*20f;
				break;

		default:
			break;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ChubbyBoyController : MonoBehaviour {

	// Use this for initialization
	private float speed;
	private Animator animator;
	public GameObject boss;
	public GameObject Fireball;
	private Vector3 defualtsize;
	private Color defualtcolor;
	private int Bigging;
	private int smalling;
	private int power;
	private int done;
	public bool pause;
	void Start () {
		speed = 1.5f;
		PlayerPrefs.DeleteAll ();
		animator = this.GetComponent<Animator> ();
		defualtsize = this.gameObject.transform.localScale;
		defualtcolor = gameObject.GetComponent<SpriteRenderer> ().color;
		Bigging = 0;
		smalling = 0;
		power = 0;
		done = 0;
		pause = false;
	}
	// Update is called once per frame
	void Update () {
		{
			if (Input.GetKeyDown (KeyCode.Escape))
				Time.timeScale = 0;
			Move ();
			if (name == "ChubbyBoy")
				SkillCheck ();
			if (smalling != 0 || Bigging != 0)
				Changesize ();
			if (power > 0 && done == 0)
				DoPower ();
			if (done > 0) {
				done++;
				done %= 60;
			}
		}
	}
	void DoPower(){
		if (Input.GetKeyDown (KeyCode.C)) {
			switch (power) {
			case 2:
				done = 1;
				GameObject fireball = Instantiate (Fireball, this.transform.position, this.transform.rotation);
				fireball.GetComponent<FireballScript> ().timeleft = 1.0f;
				fireball.GetComponent<FireballScript> ().Direction = animator.GetInteger("Direction");
				break;
			}
		}
	}
	void Changesize(){
		if (smalling > 0) {
			if (transform.localScale.x > defualtsize.x)
				transform.localScale -= new Vector3 (2.5f, 2.5f, 0) * Time.deltaTime;
			else
				smalling = 0;
		}
		if (Bigging > 0 && smalling ==0) {
			transform.localScale += new Vector3 (2.5f, 2.5f, 0) * Time.deltaTime;
			if (++Bigging == 60)
				Bigging %= 60;
		}
	}
	void SkillCheck(){
		int noPowerUp = PlayerPrefs.GetInt ("noPowerUp",0);
		if (Input.GetKeyDown (KeyCode.Alpha1) && noPowerUp > 0) { 
			PowerUp (PlayerPrefs.GetString ("PowerUp0"));
			PlayerPrefs.SetInt ("noPowerUp", --noPowerUp);
			PlayerPrefs.SetString ("PowerUp0", PlayerPrefs.GetString ("PowerUp1", ""));
			PlayerPrefs.SetString ("PowerUp1", PlayerPrefs.GetString ("PowerUp2", ""));
			PlayerPrefs.Save();
		}
		if (Input.GetKeyDown (KeyCode.Alpha2) && noPowerUp > 1) {
			PowerUp (PlayerPrefs.GetString ("PowerUp1"));
			PlayerPrefs.SetInt ("noPowerUp", --noPowerUp);
			PlayerPrefs.SetString ("PowerUp1", PlayerPrefs.GetString ("PowerUp2", ""));
			PlayerPrefs.Save();
		}
		if (Input.GetKeyDown (KeyCode.Alpha3) && noPowerUp > 2) {
			PowerUp (PlayerPrefs.GetString ("PowerUp2"));
			PlayerPrefs.SetInt ("noPowerUp", --noPowerUp);
			PlayerPrefs.Save();
		}
	}
	void PowerUp(string powername){
		ToNormal ();
		switch (powername) {
		case("Bigger"):
			Bigging = 1;
			break;
		case("Fire"):
			gameObject.GetComponent<SpriteRenderer> ().color = Color.red;
			power = 2;
			break;
		}

	}
	void ToNormal(){
		smalling = 1;
		gameObject.GetComponent<SpriteRenderer> ().color = defualtcolor;
	}
	void Move(){
		Vector3 move = new Vector3 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));
		if (move.x == 0 && move.y == 0)
			animator.SetBool ("Walking", false);
		else {
			if (Mathf.Abs (move.x) > Mathf.Abs (move.y)) {
				if (move.x < 0) {
					animator.SetInteger ("Direction", 3);
					this.GetComponent<SpriteRenderer> ().flipX = true;
				} else {
					animator.SetInteger ("Direction", 1);
					this.GetComponent<SpriteRenderer> ().flipX = false;
				}
			} else if (move.y	< 0) {
				animator.SetInteger ("Direction", 2);

			} else
				animator.SetInteger ("Direction", 0);
			animator.SetBool ("Walking", true);
		}
		if (Input.GetKey (KeyCode.Z)) {
			speed = 2.5f;
			animator.SetFloat ("speed", 1.5f);
		} else {
			speed = 1.5f;
			animator.SetFloat ("speed", 1f);
		}
		if (this.name == "Shadow") {
			Vector3 shadow = new Vector3 (boss.transform.position.x +0.234f, boss.transform.position.y - 0.934f);
			transform.position = shadow;
		}
		else if (move != Vector3.zero) transform.Translate (move * speed / move.magnitude * Time.deltaTime);
		gameObject.GetComponent<Rigidbody> ().velocity = Vector3.zero;
	}

}

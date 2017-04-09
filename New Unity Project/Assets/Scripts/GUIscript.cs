using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIscript : MonoBehaviour {

	// Use this for initialization
	public Sprite skill;
	public Sprite[] skills;
	public Sprite[] skilllist;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		int noPowerUp = PlayerPrefs.GetInt ("noPowerUp",0);
		for (int i = 0; i < noPowerUp; i++) {
			string power = PlayerPrefs.GetString ("PowerUp" + i.ToString ());
			switch (power) {
			case("Bigger"):
				skills [i] = skilllist [0];
				break;
			case("Fire"):
				skills [i] = skilllist [1];
				break;
			}
		}
	}
	void OnGUI(){
		GUIStyle style = new GUIStyle ();
		style.fontSize = 15;
		int Score = PlayerPrefs.GetInt ("Score", 0);
		if (Score == 32) {
			style.fontSize = 60;
			GUI.Label (new Rect (Screen.width / 3, Screen.height / 3, Screen.width / 6, Screen.height / 6), "LEVEL Clear",style);
		}
		GUI.Label(new Rect(0,0,Screen.width/6,Screen.height/6),"Score : "+Score.ToString(),style);
		int noPowerUp = PlayerPrefs.GetInt ("noPowerUp",0);
		Rect srect1 = new Rect (Screen.width / 16, Screen.height * 7 / 8 - skill.rect.height / 6, skill.rect.width / 6, skill.rect.height / 6);
		Rect srect2 = new Rect(Screen.width/16+skill.rect.width/6,Screen.height*7/8-skill.rect.height/6,skill.rect.width/6,skill.rect.height/6);
		Rect srect3 = new Rect (Screen.width / 16 + skill.rect.width / 6 * 2, Screen.height * 7 / 8 - skill.rect.height / 6, skill.rect.width / 6, skill.rect.height / 6);
		GUI.Box(srect1,new Texture());
		GUI.Box(srect2,new Texture());
		GUI.Box(srect3,new Texture());
		style.fontSize = 24;
		if (noPowerUp > 0) {
			Sprite s = skills [0];
			Texture t = s.texture;
			Rect tr = s.textureRect;
			Rect r = new Rect (tr.x / t.width, tr.y / t.height, tr.width / t.width, tr.height / t.height);
			GUI.DrawTextureWithTexCoords (srect1, t, r);
			GUI.Label (srect1, " 1 ",style);
		}
		if (noPowerUp > 1) {
			Sprite s = skills [1];
			Texture t = s.texture;
			Rect tr = s.textureRect;
			Rect r = new Rect (tr.x / t.width, tr.y / t.height, tr.width / t.width, tr.height / t.height);
			GUI.DrawTextureWithTexCoords (srect2, t, r);
			GUI.Label (srect2, " 2 ",style);
		}
		if (noPowerUp > 2) {
			Sprite s = skills [2];
			Texture t = s.texture;
			Rect tr = s.textureRect;
			Rect r = new Rect (tr.x / t.width, tr.y / t.height, tr.width / t.width, tr.height / t.height);
			GUI.DrawTextureWithTexCoords (srect3, t, r);
			GUI.Label (srect3, " 3 ",style);
		}
	}
}

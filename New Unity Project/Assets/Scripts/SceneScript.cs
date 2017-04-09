using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour {

	// Use this for initialization
	private bool pause;
	void Start () {
		pause = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.gameObject.name == "ChubbyBoy") {
			if (Input.GetKeyDown(KeyCode.Escape)) {
				pause = true;
				SceneManager.LoadScene("InGameMenu",LoadSceneMode.Additive);
				Time.timeScale = 0;
			}
		}
	}
	public void LoadSelection(){
		SceneManager.LoadScene ("LevelSelect");
	}
	public void ToLevel(int level){
		SceneManager.LoadScene ("Level"+level.ToString());
	}
	public void ToMainMenu(){
		SceneManager.LoadScene ("MainMenu");
	}
	public void Resume(){
		pause = false;
		Time.timeScale = 1;

		SceneManager.UnloadSceneAsync ("InGameMenu");
	}

}

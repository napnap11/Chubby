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
			if (Input.GetKeyDown(KeyCode.Escape) && !pause) {
				pause = true;
				SceneManager.LoadScene("InGameMenu",LoadSceneMode.Additive);
			}
		}
	}
	public void LoadSelection(){
		SceneManager.LoadScene ("LevelSelect");
		SceneManager.UnloadSceneAsync ("MainMenu");
	}
	public void ToLevel(int level){
		SceneManager.LoadScene ("Level"+level.ToString());
		SceneManager.UnloadSceneAsync ("LevelSelect");
	}
	public void ToMainMenu(){
		int index = SceneManager.GetActiveScene ().buildIndex;
		SceneManager.LoadScene ("MainMenu");
		SceneManager.UnloadSceneAsync (index);
	}
	public void Resume(){
		SceneManager.UnloadSceneAsync ("InGameMenu");
		pause = false;
		Time.timeScale = 1;
	}

}

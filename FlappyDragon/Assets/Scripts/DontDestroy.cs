using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour {

	private void Awake() {
		GameObject [] mainMenuMusic = GameObject.FindGameObjectsWithTag("MainMenuMusic");
		GameObject [] gameplayMusic = GameObject.FindGameObjectsWithTag("GameplayMusic");

		if(mainMenuMusic.Length > 2){
			Destroy(this.gameObject);
		}else{
			DontDestroyOnLoad(this.gameObject);
		}

		if(gameplayMusic.Length > 2){
			Destroy(this.gameObject);
		}else{
			DontDestroyOnLoad(this.gameObject);
		}

		if(SceneManager.GetActiveScene().name == "MainMenu"){
			DestroyLoop(gameplayMusic);
		}else if(SceneManager.GetActiveScene().name == "Level"){
			DestroyLoop(mainMenuMusic);
		}
		
	}

	private void DestroyLoop(GameObject[] array){
		for(int i = 0; i<array.Length; i++){
			Destroy(array[i]);
		}
	}
}

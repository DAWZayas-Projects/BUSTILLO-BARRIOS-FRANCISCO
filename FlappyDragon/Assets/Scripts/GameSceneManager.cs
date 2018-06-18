using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour {

	public static GameSceneManager Instance;

	private void Awake() {
		Instance = this;
	}
	public void LoadScene(string sceneToLoad){
		SceneManager.LoadScene(sceneToLoad);
	}

	public void QuitGame(){
		Application.Quit();
	}
}

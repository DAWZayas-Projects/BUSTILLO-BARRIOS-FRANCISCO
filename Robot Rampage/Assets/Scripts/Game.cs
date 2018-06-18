using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using  UnityEngine.SceneManagement;

public class Game : MonoBehaviour {

	public GameUI gameUI;
	public GameObject player;
	public GameObject gameOverPanel;
	public int score;
	public int waveCountDown;
	public bool isGameOver;

	static Game singleton;
	[SerializeField] RobotSpawn [] spawns;

	public int enemiesLeft;
	
	void Start () {
		singleton = this;
		StartCoroutine("increaseScoreEachSecond");
		isGameOver = false;
		Time.timeScale = 1;
		waveCountDown = 30;
		enemiesLeft = 0;
		StartCoroutine("updateWaveTimer");
		SpawnRobots();
	}
	
	void Update () {
		
	}

	void SpawnRobots() {
		foreach(RobotSpawn spawn in spawns){
			spawn.SpawnRobot();
			enemiesLeft++;
			gameUI.SetEnemyText(enemiesLeft);
		}
	}

	IEnumerator updateWaveTimer (){
		while(!isGameOver){
			yield return new WaitForSeconds(1f);
			waveCountDown--;
			gameUI.SetWaveText(waveCountDown);

			//Spawn next wave and restart count down
			if( waveCountDown == 0){
				SpawnRobots();
				waveCountDown = 30;
				gameUI.ShowNewWaveText();
			}
		}
	}

	public static void RemoveEnemy () {
		singleton.enemiesLeft--;
		singleton.gameUI.SetEnemyText(singleton.enemiesLeft);

		// Give player bonus for clearing the wave before timer is done
		if( singleton.enemiesLeft == 0){
			singleton.score +=50;
			singleton.gameUI.ShowWaveClearBonus();
		}
	}

	public static void AddRobotKIllsToScore () {
		singleton.score +=10;
		singleton.gameUI.SetScoreText(singleton.score);
	}

	IEnumerator increaseScoreEachSecond () {
		while(!isGameOver){
			yield return new WaitForSeconds(1);
			score += 1;
			gameUI.SetScoreText(score);
		}
	}

	public void OnGUI () {
		if(isGameOver && Cursor.visible == false){
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None; 
		}
	}

	public void GameOver () {
		isGameOver = true;
		Time.timeScale = 0;
		player.GetComponent<FirstPersonController>().enabled = false;
		player.GetComponent<CharacterController>().enabled = false;
		gameOverPanel.SetActive(true);
	} 

	public void RestartGame () {
		SceneManager.LoadScene(Constants.SceneBattle);
		gameOverPanel.SetActive(true);
	}

	public void ExitGame () {
		Application.Quit();
	}

	public void MainMenu () {
		SceneManager.LoadScene(Constants.SceneMenu);
	}

}

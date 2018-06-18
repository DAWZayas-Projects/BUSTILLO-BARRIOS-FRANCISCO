using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour {

	public Text topScore;
	
	void Start () {
		ScoreToScoreUI(topScore, PlayerPrefs.GetInt("TopScore"), "Top Score");
	}

	public void ScoreToScoreUI(Text scoreText, int score, string title){
		scoreText.text = title+" "+score.ToString();
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour {

	private int reward = 10;
	public GameObject secretCharacter;
	public GameObject questionSign;
	public GameObject rewardText;

	private void Start(){

		UnlockCharacter();

	}
	public void SelectCharacter(string character){
		PlayerPrefs.SetString("Avatar", character);
	}

	public void UnlockCharacter(){
		if(PlayerPrefs.GetInt("TopScore") >= reward){
			secretCharacter.gameObject.SetActive(true);
			questionSign.gameObject.SetActive(false);
			rewardText.gameObject.SetActive(false);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {
	[SerializeField] Sprite redReticle;
	[SerializeField] Sprite blueReticle;
	[SerializeField] Sprite yellowReticle;
	[SerializeField] Image reticle;
	[SerializeField] Text ammoText;
	[SerializeField] Text healthText;
	[SerializeField] Text armorText;
	[SerializeField] Text scoreText;
	[SerializeField] Text pickupText;
	[SerializeField] Text waveText;
	[SerializeField] Text enemyText;
	[SerializeField] Text waveClearText;
	[SerializeField] Text newWaveText;
	[SerializeField] Player player;


	void Start () {
		SetArmorText(player.armor);
		SetHealthText(player.health);
	}

	void Update () {
		
	}

	public void UpdateReticle() {
		switch (GunEquipper.activeWeaponType){
			case Constants.Pistol:
				reticle.sprite = redReticle;
				break;
			case Constants.Shotgun:
				reticle.sprite = yellowReticle;
				break;
			case Constants.AssaultRifle:
				reticle.sprite = blueReticle;
				break;
			default:
				return;
		}
	}

	public void SetArmorText(int armor){
		armorText.text = "Armor: "+ armor;
	}

	public void SetHealthText(int health){
		healthText.text = "Health: "+ health;
	}

	public void SetAmmoText(int ammo){
		ammoText.text = "Ammo: "+ ammo;
	}

	public void SetScoreText(int score){
		scoreText.text = ""+ score;
	}

	public void SetWaveText(int time){
		waveText.text = "Next Wave : "+ time;
	}

	public void SetEnemyText(int enemies){
		enemyText.text = "Enemies: "+ enemies;
	}

	public void ShowWaveClearBonus() {
		waveClearText.GetComponent<Text>().enabled = true;
		StartCoroutine("hideWaveClearBonus");
	}

	IEnumerator hideWaveClearBonus() {
		yield return new WaitForSeconds(4);
		waveClearText.GetComponent<Text>().enabled = false;
	}
	
	public void SetPickupText(string text) {
		pickupText.GetComponent<Text>().enabled = true;
		pickupText.text = text;
		//Restart the coroutine so it doesn't end early
		StopCoroutine("hidePickupText");
		StartCoroutine("hidePickupText");
	}

	IEnumerator hidePickupText() {
		yield return new WaitForSeconds(4);
		pickupText.GetComponent<Text>().enabled = false;
	}

	public void ShowNewWaveText() {
		StartCoroutine("hideNewWaveText");
		newWaveText.GetComponent<Text>().enabled =  true;
	}

	IEnumerator hideNewWaveText() {
		yield return new WaitForSeconds(4);
		newWaveText.GetComponent<Text>().enabled = false;
	}

}

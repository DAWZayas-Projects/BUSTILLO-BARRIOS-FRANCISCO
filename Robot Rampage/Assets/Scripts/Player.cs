using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public int health;
	public int armor;

	public GameUI gameUI;
	public GunEquipper gunEquipper;
	public Game game;

	public AudioClip playerDead;


	Ammo ammo;



	void Start () {
		ammo = GetComponentInChildren<Ammo>();
		gunEquipper = GetComponentInChildren<GunEquipper>();
	}
	
	void Update () {
		
	}

	public void TakeDamage(int amount) {
		int healthDamage = amount;

		if(armor > 0){
			int effectiveArmor = armor * 2;
			effectiveArmor -= healthDamage;

			// If there is still armor, don't need to process
			// Health damage
			if(effectiveArmor > 0){
				armor = effectiveArmor / 2;
				gameUI.SetArmorText(armor);
				return;
			}

			armor = 0;
			gameUI.SetArmorText(armor);
		}

		health -= healthDamage;
		gameUI.SetHealthText(health);

		if(health == 0){
			GetComponent<AudioSource>().PlayOneShot(playerDead);
			game.GameOver();
		}
	}

	private void pickupHealth(){
		health += 50;

		if(health > 200){
			health = 200;
		}
		gameUI.SetPickupText("Health picked up + 50 Health");
		gameUI.SetHealthText(health);
	}

	private void pickupArmor(){
		armor += 15;
		gameUI.SetPickupText("Armor picked up + 15 Armor");
		gameUI.SetArmorText(armor);
	}

	private void pickupAssaultRiffleAmmo() {
		ammo.AddAmmo(Constants.AssaultRifle, 50);
		gameUI.SetPickupText("Assault riffle ammo picked up + 50 ammo");
		if(gunEquipper.GetActiveWeapon().tag == Constants.AssaultRifle){
			gameUI.SetAmmoText(ammo.GetAmmo(Constants.AssaultRifle));
		}
	}

	private void pickupPistolAmmo() {
		ammo.AddAmmo(Constants.Pistol, 20);
		gameUI.SetPickupText("Pistol ammo picked up + 20 ammo");
		if(gunEquipper.GetActiveWeapon().tag == Constants.Pistol){
			gameUI.SetAmmoText(ammo.GetAmmo(Constants.Pistol));
		}
	}

	private void pickupShotgunAmmo() {
		ammo.AddAmmo(Constants.Shotgun, 10);
		gameUI.SetPickupText("Shotgun ammo picked up + 10 ammo");
		if(gunEquipper.GetActiveWeapon().tag == Constants.Shotgun){
			gameUI.SetAmmoText(ammo.GetAmmo(Constants.Shotgun));
		}
	}

	public void PickupItem(int pickupType){
		switch(pickupType){
			case Constants.PickUpArmor:
			pickupArmor();
			break;
			case Constants.PickUpHealth:
			pickupHealth();
			break;
			case Constants.PickUpPistolAmmo:
			pickupPistolAmmo();
			break;
			case Constants.PickUpAssaultRiffleAmmo:
			pickupAssaultRiffleAmmo();
			break;
			case Constants.PickUpShotgunAmmo:
			pickupShotgunAmmo();
			break;
			default:
			Debug.LogError("Bad pickup type passed: "+pickupType);
			break; 
		}
	}

}

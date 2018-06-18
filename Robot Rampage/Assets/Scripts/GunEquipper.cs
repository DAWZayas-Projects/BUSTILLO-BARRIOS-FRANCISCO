using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEquipper : MonoBehaviour {

	public static string activeWeaponType;
	public static string [] weaponTypes = new string [] {Constants.Pistol, Constants.AssaultRifle, Constants.Shotgun};
	public static int activeWeaponNumber = 0;
	
	public GameObject pistol;
	public GameObject assaultRifle;
	public GameObject shotgun;

	GameObject activeGun;

	[SerializeField] GameUI gameUI;
	[SerializeField] Ammo ammo;


	void Start () {
		activeWeaponType = weaponTypes[activeWeaponNumber];
		activeGun = pistol;
	}
	
	
	void Update () {
		changeWeaponKey();
		changeWeaponWheel();
	}

	void loadWeapon (GameObject weapon){
		pistol.SetActive(false);
		assaultRifle.SetActive(false);
		shotgun.SetActive(false);
		weapon.SetActive(true);
		activeGun = weapon;
		gameUI.SetAmmoText(ammo.GetAmmo(activeGun.tag));
	}

	public void changeWeaponKey (){
		if(Input.GetKeyDown("1")){
			loadWeapon(pistol);
			activeWeaponNumber = 0;

		}else if(Input.GetKeyDown("2")){
			loadWeapon(assaultRifle);
			activeWeaponNumber = 1;
			
		}else if(Input.GetKeyDown("3")){
			loadWeapon(shotgun);
			activeWeaponNumber = 2;
			

		}

		activeWeaponType = weaponTypes[activeWeaponNumber];
		gameUI.UpdateReticle();
		gameUI.SetAmmoText(ammo.GetAmmo(activeGun.tag));
	}

	public void changeWeaponWheel (){

		int previousSelectedWeapon = activeWeaponNumber;

		if(Input.GetAxis("Mouse ScrollWheel") < 0f){
			if(activeWeaponNumber >= transform.childCount -1){
				activeWeaponNumber = 0;

			}else{
				activeWeaponNumber++;

			}
		}
		if(Input.GetAxis("Mouse ScrollWheel") > 0f){
			if(activeWeaponNumber <= 0){
				activeWeaponNumber = transform.childCount -1;

			}else{
				activeWeaponNumber--;

			}
		}
		if(previousSelectedWeapon != activeWeaponNumber){
			SelectWeapon();
			
		}
	}

	void SelectWeapon(){

		int i = 0;

		foreach(Transform weapon in transform){
			
			if(i == activeWeaponNumber){
				loadWeapon(weapon.gameObject);
				activeGun = weapon.gameObject;
				activeWeaponType = weaponTypes[activeWeaponNumber];
				

			}else{
				weapon.gameObject.SetActive(false);

			}
			i++;
		}
	}

	public GameObject GetActiveWeapon (){
		return activeGun;
	}
}

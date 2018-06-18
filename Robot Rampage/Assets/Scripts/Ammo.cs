using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour {

	[SerializeField] GameUI gameUI;
	[SerializeField] int pistolAmmo = 20;
	[SerializeField] int assaultRiffleAmmo = 50;
	[SerializeField] int shotgunAmmo = 	10;

	public Dictionary <string, int> tagToAmmo;

	void Awake() {
		tagToAmmo = new Dictionary<string, int> {
			{Constants.Pistol, pistolAmmo},
			{Constants.Shotgun, shotgunAmmo},
			{Constants.AssaultRifle, assaultRiffleAmmo}
		};	
	}
	void Start () {
		
	}
	
	void Update () {
		
	}

	public void AddAmmo(string tag, int ammo) {
		
		ThrowErrorTag(tag);

		tagToAmmo[tag] += ammo;
	}

	// Returns true if gun has ammo
	public bool HasAmmo(string tag) {
		
		ThrowErrorTag(tag);

		return tagToAmmo[tag] > 0;
	}

	public int GetAmmo(string tag) {
		ThrowErrorTag(tag);

		return tagToAmmo[tag];
	}

	public void ConsumeAmmo(string tag) {
		ThrowErrorTag(tag);

		tagToAmmo[tag]--;
		gameUI.SetAmmoText(tagToAmmo[tag]);
	}
	

	public void ThrowErrorTag(string tag) {
		if(!tagToAmmo.ContainsKey(tag)){
			Debug.LogError("Unrecognized gun type passed: "+tag);
		}
	}

}

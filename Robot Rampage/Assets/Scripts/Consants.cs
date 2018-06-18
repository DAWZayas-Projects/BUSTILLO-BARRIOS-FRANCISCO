using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants {
	// Scenes
	public const string SceneBattle = "Battle";
	public const string SceneMenu = "Main Menu";

	// Gun Types
	public const string Pistol = "Pistol";
	public const string Shotgun = "Shotgun";
	public const string AssaultRifle = "AssaultRifle";

	// Robot Types
	public const int PickUpPistolAmmo = 1;
	public const int PickUpAssaultRiffleAmmo = 2;
	public const int PickUpShotgunAmmo = 3;
	public const int PickUpHealth = 4;
	public const int PickUpArmor = 5;

	// Misc
	public const string Game = "Game";
	public const float CameraDefaultZoom = 60f;


	public static readonly int[] AllPickUpTypes = new int [5]{
		PickUpPistolAmmo,
		PickUpAssaultRiffleAmmo,
		PickUpShotgunAmmo,
		PickUpHealth,
		PickUpArmor
	};
}
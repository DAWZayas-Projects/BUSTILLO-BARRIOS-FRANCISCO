﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

	public int type;

	void Start () {
		
	}
	
	
	void Update () {
		
	}

	void OnTriggerEnter(Collider collider) {
		if(collider.gameObject.GetComponent<Player>() != null && collider.gameObject.tag == "Player" ){
			collider.gameObject.GetComponent<Player>().PickupItem(type);
			Destroy(gameObject);
			GetComponentInParent<PickupSpawn>().PickupWasPickedUp();
		}	
	}
}

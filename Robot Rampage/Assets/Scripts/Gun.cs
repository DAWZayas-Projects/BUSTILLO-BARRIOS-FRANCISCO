using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

	public float fireRate;
	public float zoomFactor;
	public int damage;
	public int range;

	public Ammo ammo;
	public AudioClip liveFire;
	public AudioClip dryFire;
	protected float lastFireTime;

	float zoomFOV;
	float zoomSpeed = 6;
	Camera myCamera;
	void Start (){
		myCamera =  Camera.main;
		zoomFOV = Constants.CameraDefaultZoom / zoomFactor;
		lastFireTime = Time.time -10;
		
	}
	
	protected virtual void Update (){
		//Right Click Zoom
		if(Input.GetMouseButton(1)){
			myCamera.fieldOfView = Mathf.Lerp(myCamera.fieldOfView, zoomFOV, zoomSpeed * Time.deltaTime);

		}else{
			myCamera.fieldOfView = Constants.CameraDefaultZoom;
		}
	}

	protected void Fire (){

		if(ammo.HasAmmo(tag)){
			GetComponent<AudioSource>().PlayOneShot(liveFire);
			ammo.ConsumeAmmo(tag);

			GetComponentInChildren<Animator>().Play("Fire");

			Ray ray = myCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
			
			RaycastHit hit;

			if(Physics.Raycast(ray, out hit, range)){
				processHit(hit.collider.gameObject);
			}

		}else{
			GetComponent<AudioSource>().PlayOneShot(dryFire);

		}

		

	}

	private void processHit(GameObject hitobject){
		if(hitobject.GetComponent<Player>() != null){
			hitobject.GetComponent<Player>().TakeDamage(damage);
		}

		if(hitobject.GetComponent<Robot>() != null){
			hitobject.GetComponent<Robot>().TakeDamage(damage);
		}
	}
}

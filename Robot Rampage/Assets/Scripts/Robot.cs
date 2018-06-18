using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Robot : MonoBehaviour {

	[SerializeField] private string robotType;

	public int health;
	public int range;
	public float fireRate;
	public Transform missileFireSpot;
	public Animator robot;

	NavMeshAgent agent;
	Transform player;
	float timeLastFired;
	bool isDead;

	[SerializeField] GameObject missilePrefab;
	[SerializeField] AudioClip deathSound;
	[SerializeField] AudioClip fireSound;
	[SerializeField] AudioClip weakHitSound;


	void Start () {
		isDead = false;
		agent = GetComponent<NavMeshAgent>();
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	

	void Update () {
		if(isDead){
			return;
		}

		transform.LookAt(player);
		agent.SetDestination(player.position);

		if(Vector3.Distance(transform.position, player.position) < range && Time.time - timeLastFired > fireRate){
				timeLastFired = Time.time;
				Fire();
		}

	}

	void Fire() {
		GameObject missile = Instantiate(missilePrefab);
		missile.transform.position = missileFireSpot.transform.position;
		missile.transform.rotation = missileFireSpot.transform.rotation;
		
		robot.Play("Fire");

		GetComponent<AudioSource>().PlayOneShot(fireSound);
	}

	public void TakeDamage(int amount) {
		if(isDead){
			return;
		}

		health -= amount;

		if(health <= 0){
			isDead = true;
			robot.Play("Die");
			StartCoroutine("DestroyRobot");
			Game.RemoveEnemy();
			Game.AddRobotKIllsToScore();
			GetComponent<AudioSource>().PlayOneShot(deathSound);
		}else{
			GetComponent<AudioSource>().PlayOneShot(weakHitSound);
		}
	}

	IEnumerator DestroyRobot() {
		yield return new WaitForSeconds(1.5f);
		Destroy (gameObject);
	}
}

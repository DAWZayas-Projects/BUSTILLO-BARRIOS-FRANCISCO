	using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotSpawn : MonoBehaviour {

	[SerializeField] GameObject [] robots;

	int timesSpawned;
	int healthbonus = 0;

	void Start () {
		
	}

	void Update () {
		
	}

	public void SpawnRobot(){
		timesSpawned++;
		healthbonus += 1 * timesSpawned;
		GameObject robot = Instantiate(robots[Random.Range(0, robots.Length)]);
		robot.transform.position = transform.position;
		robot.GetComponent<Robot>().health += healthbonus;
	}
}

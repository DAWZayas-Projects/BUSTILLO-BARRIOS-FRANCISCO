using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour {


	private float obstaclesVelocity = -4f;
	private float obstaclesDistance = 12f;
	private float obstaclesDesapearingDistance = -7f;

	private void Update () {

		if(GameManager.Instance.IsGameActive){
			
			MoveObstacle();

			if(transform.position.x < obstaclesDesapearingDistance){
				transform.position = ResetObstaclePosition();
			}
		}
	}	

	private Vector3 ResetObstaclePosition(){
		Vector3 temporalPosition = transform.position + (new Vector3(obstaclesDistance,0f,0f));
		temporalPosition.y = Random.Range(4.17f, 7.4f);
		return temporalPosition;
	}

	private void MoveObstacle(){
		transform.position += new Vector3(obstaclesVelocity * Time.deltaTime, 0f, 0f);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour {

	public float count;
	public int xaxis;
	public int yaxis;
	public int zaxis;
	public float x,y,z;
	public int number = 20;
	public List<GameObject> obstaclePrefabs;
	public List<GameObject> obstacleInScene;
	private int hit = 0;
	private GameObject Obstacle;
	public int scoreValue;
	private ScoreManager scoreManager;

	void Start(){
		GameObject scoreManagerObject = GameObject.FindWithTag ("GameController");
		if (scoreManagerObject != null)
		{
			scoreManager = scoreManagerObject.GetComponent <ScoreManager>();
		}
	}

	private float OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			placeTree();
			scoreManager.AddScore (scoreValue);
			if (hit == 0) {
				count += 20f;
				hit = 1;
			}
			else if (hit == 1) {
				count += 10f;
			}

		}

		return count;
	}

	void placeTree(){
		for (int t = 0; t < number; t++) {
			int randomIndex = Random.Range(0, obstaclePrefabs.Count);
			GameObject Obstacle = Instantiate (obstaclePrefabs[randomIndex], GeneratedPosition (), Quaternion.identity);

			if (randomIndex == 0) {
				Obstacle.transform.Translate (0, 0, count);
			} 
			else if (randomIndex == 1) {
				Obstacle.transform.Translate (-10, 0, count);
			}

			obstacleInScene.Add (Obstacle);

			Obstacle = obstacleInScene [0];
			Destroy (Obstacle);
			obstacleInScene.RemoveAt (0);
		}
	}

	Vector3 GeneratedPosition(){
		x = UnityEngine.Random.Range (-xaxis + 56, xaxis + 56);
		y = UnityEngine.Random.Range (-yaxis + .48f, yaxis + .48f);
		z = UnityEngine.Random.Range (-zaxis, zaxis + 5);
		transform.Translate (0,0,.5f);
		return new Vector3 (x, y, z);
	}
}

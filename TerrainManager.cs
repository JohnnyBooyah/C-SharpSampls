using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManager : MonoBehaviour {

	public List<GameObject> terrainPrefabs;
	private float distanceNewTerrain = 10f;
	public float distanceMoveManager = 10f;

	public List<GameObject> terrainInScene;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") {
			int randomIndex = Random.Range (0, terrainPrefabs.Count);
			Vector3 temp = new Vector3 (0, 0, transform.position.z + distanceNewTerrain);

			GameObject terrain = Instantiate (terrainPrefabs [randomIndex], temp, Quaternion.identity);
			terrainInScene.Add (terrain);

			terrain = terrainInScene [0];
			Destroy (terrain);
			terrainInScene.RemoveAt (0);

			transform.Translate (0, 0, distanceMoveManager);
		}
	}
}

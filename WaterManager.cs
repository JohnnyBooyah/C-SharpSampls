using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterManager : MonoBehaviour {
	public List<GameObject> logPrefabs;
	public GameObject leftPosObj, rightPosObj;
	private bool continueSpawnLogs;


	// Use this for initialization
	void Start() {
		continueSpawnLogs = true;
		StartCoroutine(SpawnLog());

		int randomIndex = Random.Range(0, logPrefabs.Count);
		int randomStart = Random.Range(0, 2); //0 is left, 1 is right
	}

	IEnumerator SpawnLog()
	{
		while(continueSpawnLogs)
		{
			int randomIndex = Random.Range(0, logPrefabs.Count);
			int randomStart = Random.Range(0, 2); //0 is left, 2 is right


			if (randomStart == 0)
			{
				Vector3 leftPos = new Vector3(leftPosObj.transform.position.x,
					leftPosObj.transform.position.y,
					leftPosObj.transform.position.z);
				GameObject car = Instantiate(logPrefabs[randomIndex], leftPos, Quaternion.Euler(270,0,90));
				car.GetComponent<carController>().isGoingLeft = false;
				car.transform.parent = gameObject.transform;
			}
			else
			{
				Vector3 rightPos = new Vector3(rightPosObj.transform.position.x,
					rightPosObj.transform.position.y,
					rightPosObj.transform.position.z);
				GameObject car = Instantiate(logPrefabs[randomIndex], rightPos, Quaternion.Euler(270,0,270));
				car.GetComponent<carController>().isGoingLeft = true;
				car.transform.parent = gameObject.transform;

			}

			yield return new WaitForSeconds(1f);
		}

	}
}

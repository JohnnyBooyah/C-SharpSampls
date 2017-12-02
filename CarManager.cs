using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour {
    public List<GameObject> carPrefabs;
    public GameObject leftPosObj, rightPosObj;
    private bool continueSpawnCars;


    // Use this for initialization
    void Start() {
        continueSpawnCars = true;
        StartCoroutine(SpawnCar());

        int randomIndex = Random.Range(0, carPrefabs.Count);
        int randomStart = Random.Range(0, 2); //0 is left, 1 is right
    }
	
    IEnumerator SpawnCar()
    {
        while(continueSpawnCars)
        {
            int randomIndex = Random.Range(0, carPrefabs.Count);
            int randomStart = Random.Range(0, 2); //0 is left, 2 is right


            if (randomStart == 0)
            {
                Vector3 leftPos = new Vector3(leftPosObj.transform.position.x,
                    leftPosObj.transform.position.y,
                    leftPosObj.transform.position.z);
				GameObject car = Instantiate(carPrefabs[randomIndex], leftPos, Quaternion.Euler(270,0,90));
                car.GetComponent<carController>().isGoingLeft = false;
				car.transform.parent = gameObject.transform;
            }
            else
            {
                Vector3 rightPos = new Vector3(rightPosObj.transform.position.x,
                    rightPosObj.transform.position.y,
                    rightPosObj.transform.position.z);
				GameObject car = Instantiate(carPrefabs[randomIndex], rightPos, Quaternion.Euler(270,0,270));
                car.GetComponent<carController>().isGoingLeft = true;
				car.transform.parent = gameObject.transform;
            }

            yield return new WaitForSeconds(1f);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleController : MonoBehaviour {
	private void OnTriggerEnter(Collider collision)
	{
		if (gameObject.tag == "Vechicle") {
			Destroy (gameObject);
		}


		if (collision.gameObject.tag == "Road") {
			Destroy (gameObject);
		}

		if (collision.gameObject.tag == "Water") {
			Destroy (gameObject);
		}
	}
}
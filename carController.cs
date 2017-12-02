using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour {


    public float speed;
    public bool isGoingLeft; //needs to be initialized by the car manager

	// Use this for initialization
	void Start () {
        speed = 0.1f;
	}
	
	// Update is called once per frame
	void Update () {
		if(isGoingLeft)
        {
            transform.Translate(0, -speed, 0);
        }
        else
        {
            transform.Translate(0, -speed, 0);
        }

	}

    private void OnTriggerEnter(Collider other)
    {
		if (other.gameObject.tag == "Obstacle") {
			Destroy (other.gameObject);
		}

		if (other.gameObject.tag == "Wall") {
			Destroy (gameObject);
		}
		if (other.gameObject.tag == "Log") {
			other.gameObject.transform.Translate (-speed,-speed,-speed);
		}
    }
}

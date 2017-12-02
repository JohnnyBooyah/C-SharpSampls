using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    Rigidbody rb;
    public float speed;
	bool hitFloor = true;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = 5;
    }

    private void FixedUpdate()
    {
        float moveHorizonatal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizonatal, 0.0f, moveVertical);

        rb.velocity = movement * speed;

		/*if(hitFloor == false)
		{
			rb.AddForce(5,0,0);
    	}*/
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Vechicle")
        {
            gameObject.transform.DetachChildren();
            Destroy(gameObject);
            Destroy(collision.gameObject);
			Application.LoadLevel("mainMenu");
        }

		if(collision.gameObject.tag == "Log")
		{
			hitFloor = false;
		}
    }
}
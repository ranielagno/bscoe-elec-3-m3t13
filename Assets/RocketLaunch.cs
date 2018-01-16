using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLaunch : MonoBehaviour {
    Rigidbody rigidbody;
    Boolean checker;
    
	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        ProcessInput();
	}

    private void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidbody.AddRelativeForce(Vector3.up * 15);

        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            transform.position = new Vector3(-8.74f, 2.69f, 0f);
            transform.rotation = Quaternion.identity;
            rigidbody.angularVelocity = new Vector3(0f, 0f, 0f);
            rigidbody.velocity = new Vector3(0f, 0f, 0f);
        } 

        if (collision.gameObject.tag == "Ending")
        {
            checker = true;

            if (checker)
            {
                collision.gameObject.GetComponent<Renderer>().material.color = Color.green;
            }

        }
    }

    
}
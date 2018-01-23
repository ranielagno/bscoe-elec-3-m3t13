using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FirstRocket : MonoBehaviour {

    Rigidbody rigidbody;
    SceneManager sceneManager;
    Boolean cheat;
    [SerializeField] float rocketThrust;
    [SerializeField] float rocketRotate;
    AudioSource audioSource;
    
    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        cheat = false;
        rocketThrust = 850f;
        rocketRotate = 300f;
}
	
	// Update is called once per frame
	void Update () {
        ProcessInput(); 
	}

    private void ProcessInput()
    {
        float rocketRotate = rocketThrust * Time.deltaTime;


        if (Input.GetKeyDown(KeyCode.O))
        {
            cheat = !cheat;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            audioSource.Play();
            rigidbody.AddRelativeForce(Vector3.up * Time.deltaTime * rocketThrust);

        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rocketRotate * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * rocketRotate * Time.deltaTime);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle" && !cheat)
        {
            SceneManager.LoadScene("Level1", LoadSceneMode.Single);
        } 

        else if (collision.gameObject.tag == "TargetPadLevel1")
        {
            SceneManager.LoadScene("Level2", LoadSceneMode.Single);
        }
        else if (collision.gameObject.tag == "TargetPadLevel2")
        {
            SceneManager.LoadScene("Level3", LoadSceneMode.Single);
        }
        else if (collision.gameObject.tag == "TargetPadLevel3")
        {
            collision.gameObject.GetComponent<Renderer>().material.color = Color.green;

        }
    }

    

    
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingPad : MonoBehaviour {

    GameObject first_rocket;
    GameObject landing_pad;

    // Use this for initialization
    void Start () {
        first_rocket = GameObject.Find("First Rocket");
        landing_pad = GameObject.Find("Target Pad");

    }

    // Update is called once per frame
    void Update () {
        SetLandingPadColor();
	}

    private void SetLandingPadColor()
    {
        float distance1 = Vector3.Distance(first_rocket.transform.position, landing_pad.transform.position);
        bool check = landing_pad.gameObject.GetComponent<Renderer>().material.GetColor("_Color") != Color.green;
        
        if (distance1 < 10 && check)
        {
            landing_pad.gameObject.GetComponent<Renderer>().material.color = Color.blue;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public Vector3 offset;

    Transform ovrPlayerController;

	// Use this for initialization
	void Start ()
    {
        ovrPlayerController = GameObject.FindObjectOfType<OVRPlayerController>().gameObject.transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = ovrPlayerController.position+offset;
	}
}

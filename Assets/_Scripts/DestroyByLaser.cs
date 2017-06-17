using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByLaser : MonoBehaviour {

	private GameObject camera;
	private ClickHandler clickHandler;

	// Use this for initialization
	void Start () {
		GameObject cameraObject = GameObject.FindGameObjectWithTag ("MainCamera");
		if (cameraObject != null) {
			camera = cameraObject;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
	
	private Animator hammerDown;
	private LineRenderer laserline;
	private GameObject camera;
	private GameObject laserEnd;
	public bool fire = false;
	public Vector3 shootDirection;

	// Use this for initialization
	void Start () {
		GameObject hammerObject = GameObject.FindGameObjectWithTag ("Hammer");
		GameObject hammerTipObject = GameObject.FindGameObjectWithTag ("HammerTip");
		GameObject laserEndObject = GameObject.FindGameObjectWithTag ("LaserEnd");
		GameObject cameraObject = GameObject.FindGameObjectWithTag ("MainCamera");
		if (hammerObject != null && hammerTipObject != null)
		{
			hammerDown = hammerObject.GetComponent <Animator>();
			camera = cameraObject;
			laserline = hammerTipObject.GetComponent <LineRenderer> ();
			laserEnd = laserEndObject;
			laserline.enabled = false;
			hammerDown.Play ("AxeUp");
		}
		if (hammerDown == null || laserline == null)
		{
			Debug.Log ("GameObject initialize error");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnPointerDown(PointerEventData eventData)
	{
		hammerDown.speed = 2;
		hammerDown.Play ("AxeDown");
		//Debug.Log ("pointer down!");
		fire = true;
		StartCoroutine ("FireLaser");
	}
		
	public void OnPointerUp(PointerEventData eventData)
	{
		fire = false;
		hammerDown.speed = 3;
		hammerDown.Play ("AxeUp");
		//Debug.Log ("pointer Up!");
	}

	IEnumerator FireLaser (){
		laserline.enabled = true;
		while (fire) {
			shootDirection = camera.transform.forward;
			shootDirection = shootDirection * 100 - laserline.transform.position;
			laserline.transform.forward = shootDirection;
			laserEnd.transform.position = shootDirection;

			yield return null;
		}
		laserline.enabled = false;
	}
}

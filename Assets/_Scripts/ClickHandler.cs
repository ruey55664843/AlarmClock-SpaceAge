using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
	
	private Animator hammerDown;

	// Use this for initialization
	void Start () {
		GameObject hammerObject = GameObject.FindGameObjectWithTag ("Hammer");
		if (hammerObject != null)
		{
			hammerDown = hammerObject.GetComponent <Animator>();
		}
		if (hammerDown == null)
		{
			Debug.Log ("Cannot find 'Hammer Animator' script");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnPointerDown(PointerEventData eventData)
	{
		hammerDown.speed = 2;
		hammerDown.Play ("AxeSwing");
		Debug.Log ("pointer down!");
	}
		
	public void OnPointerUp(PointerEventData eventData)
	{
		hammerDown.speed = 3;
		hammerDown.Play ("AxeSwingUp");
		Debug.Log ("pointer Up!");
	}

}

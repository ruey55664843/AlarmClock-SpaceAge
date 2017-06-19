using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Rulebook : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler {

	//public GameObject Sif;

	public GameObject Cover;
	public GameObject p1;
	public GameObject p2;
	public GameObject p3;
	public GameObject p4;

	//private AudioSource source;
	private int mode;

	void Start (){
		mode = 0;
		Cover.SetActive (true);
		p1.SetActive (false);
		p2.SetActive (false);
		p3.SetActive (false);
		p4.SetActive (false);
	}

	void Update() {

	}

	public void OnPointerDown(PointerEventData eventData)
	{
		mode++;
		//Debug.Log (mode);
		if (mode == 5)
			mode = 0;
		DecideText ();
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		//DecideText ();
	}

	public void DecideText (){
		Cover.SetActive (false);
		p1.SetActive (false);
		p2.SetActive (false);
		p3.SetActive (false);
		p4.SetActive (false);
		if(mode == 0)
		    Cover.SetActive (true);
		else if(mode == 1)
			p1.SetActive (true);
		else if(mode == 2)
			p2.SetActive (true);
		else if(mode == 3)
			p3.SetActive (true);
		else if(mode == 4)
			p4.SetActive (true);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		mode = 0;
		DecideText ();
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LokiControl : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
	public GameObject Loki;
	public TextMesh hintText;
	public AudioClip Enough;

	private AudioSource source;
	private int mode;

	void Start (){
		mode = 0;
		Loki.SetActive (true);
		hintText.text = "";
		source = GetComponent<AudioSource> ();
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		mode++;
		DecideText ();
		if (mode == 3) {
		   source.PlayOneShot (Enough);
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		DecideText ();
	}

	public void DecideText (){
		if (mode == 0) 
			hintText.text = "Hey Brother! \nHaving fun fighting\n      in Jotunheim?\nWell, I'm not helping you";
		else if (mode == 1)
			hintText.text = "I'm not aiding you, \n So get the hell out of here!";
		else if (mode == 2)
			hintText.text = "Stop it!\n And I mean it!\n STOP IT!";
		else if (mode == 3)
			hintText.text = "This is your last WARNING!!";
		else if (mode >= 4)
			Application.Quit();
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		hintText.text = "";
		if (mode != 0)
			mode = 1;
	}
}

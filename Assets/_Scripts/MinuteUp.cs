using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MinuteUp : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
	//public GameObject score;
	public GameObject button;

	private int curValue = 0;
	private AudioSource source;

	void Start (){
		source = GetComponent<AudioSource> ();
	}
		
	public void OnPointerDown(PointerEventData eventData)
	{
		curValue = MenuController.control.minute;
		if (curValue < 55) {
			curValue += 5;
		} else {
			curValue = 0;
		}
		MenuController.control.minute = curValue;
		source.Play ();
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		//score.SetActive (true);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		//score.SetActive (false);
	}
}
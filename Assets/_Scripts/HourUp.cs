using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HourUp : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
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
		curValue = MenuController.control.hour;
		if (curValue < 11) {
			curValue++;
		} else {
			curValue = 0;
		}
		MenuController.control.hour = curValue;
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

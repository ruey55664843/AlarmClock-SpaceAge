using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ModeSwitch : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
	public GameObject groot;
	public GameObject babyGroot;
	public TextMesh hintText;
	public AudioClip iAmGroot;
	public AudioClip iAmGrootBaby;

	private AudioSource source;
	private int mode;

	void Start (){
		mode = MenuController.control.gameMode;
		if (mode == 1) {
			babyGroot.SetActive (false);
			groot.SetActive (true);
		} else {
			groot.SetActive (false);
			babyGroot.SetActive (true);
		}
		hintText.text = "";
		source = GetComponent<AudioSource> ();
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		mode = MenuController.control.gameMode;
		if (mode == 0) {
			MenuController.control.gameMode = 1;
			babyGroot.SetActive (false);
			groot.SetActive (true);
			source.PlayOneShot (iAmGroot);
			//Debug.Log ("0 to 1");
		} else {
			MenuController.control.gameMode = 0;
			groot.SetActive (false);
			babyGroot.SetActive (true);
			source.PlayOneShot (iAmGrootBaby);
			//Debug.Log ("1 to 0");
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		mode = MenuController.control.gameMode;
		if (mode == 0) {
			hintText.text = "Switch to \n Extreme Mode !";
		} else {
			hintText.text = "Switch to \n Normal Mode";
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		hintText.text = "";
	}
}

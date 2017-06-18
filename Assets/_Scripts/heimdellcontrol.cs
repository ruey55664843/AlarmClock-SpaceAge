using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class heimdellcontrol : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
	//public GameObject Sif;
	public TextMesh hintText;
	public GameObject Bifrost;
	public AudioClip Opening;

	private AudioSource source;
	private int mode;

	void Start (){
		mode = 0;
		Bifrost.SetActive (false);
		hintText.text = "";
		source = GetComponent<AudioSource> ();
	}

	void Update() {

	}

	public void OnPointerDown(PointerEventData eventData)
	{
		mode++;
		DecideText ();
		if (mode == 2) {
			hintText.text = "The bifrost shall be opened";
			StartCoroutine (GoToGame());
		}

	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		DecideText ();
	}

	public void DecideText (){
		if (mode == 0)
			hintText.text = "Ymir is striking!! \nYou must go to Jotunheim!!\nImmediately!!!!";
		else if (mode == 1)
			hintText.text = "Talk to me again when\n  you're ready to go!\nDo be fast";
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		hintText.text = "";
		mode = 0;
	}

	IEnumerator GoToGame (){
		Bifrost.SetActive (true);
		source.PlayOneShot (Opening);
		yield return new WaitForSeconds (6);
		Application.LoadLevel ("Thor");
	}
}

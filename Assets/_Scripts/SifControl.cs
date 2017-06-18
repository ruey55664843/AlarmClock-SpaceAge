using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SifControl : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
	//public GameObject Sif;
	public TextMesh hintText;
	//public AudioClip Enough;

	//private AudioSource source;
	private int mode;

	void Start (){
		mode = 0;
		//Loki.SetActive (true);
		hintText.text = "";
		//source = GetComponent<AudioSource> ();
	}

	void Update() {
		
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		mode++;
		//transform.LookAt(Camera.main.transform);
		DecideText ();
		if (mode == 2) {
			hintText.text = "Let's go shooting!";
			Application.LoadLevel ("Universe");
		}

	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		DecideText ();
	}

	public void DecideText (){
		if (mode == 0)
			hintText.text = "Thor, dear friend! \nWanna train before action?\n";
		else if (mode == 1)
			hintText.text = "Click me again to\n   enter simulation hub";
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		hintText.text = "";
		mode = 0;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class odinspeech : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
	public TextMesh hintText;

	private int mode;

	void Start (){
		mode = 0;
		hintText.text = "";
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		mode++;
		if (mode == 4) {
			MenuController.control.shootRecords.Clear ();
		}
		DecideText ();

	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		DecideText ();
	}

	public void DecideText (){
		if (mode == 0)
			hintText.text = "My son!!\n  Nice Job Guarding the Realm!";
		else if (mode == 1)
			hintText.text = "The scores below are the\n       records of your bravery\nDo Enjoy!!";
		else if (mode == 2)
			hintText.text = "Wanna Reset?\n  Click me again to confirm";
		else if (mode == 3)
			hintText.text = "Are you certain?\n  There is no turning back";
		else if (mode == 4) {
			hintText.text = "Very Well.\n  The records have been cleaned";
			mode = 0;
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		hintText.text = "";
		if (mode != 0)
			mode = 1;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownBarController : MonoBehaviour {

	public GameObject s1;
	public GameObject s2;
	public GameObject s3;
	public GameObject s4;
	public GameObject s5;

	//public float cooldown;

	private Thor_GameControl gameController;

	void Start () {
		UpdateCooldownStatus (100f);
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <Thor_GameControl>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void Update () {
		if (gameController.gameIsStart ()) {
			float cooldown = gameController.getCooldown ();
			UpdateCooldownStatus (cooldown);
			if (cooldown == 100f) {
				StartCoroutine (Blink ());
			}
		}
	}

	void UpdateCooldownStatus (float cooldown){
		s5.SetActive ((cooldown >= 100f) ? true : false);
		s4.SetActive ((cooldown >= 80f) ? true : false);
		s3.SetActive ((cooldown >= 60f) ? true : false);
		s2.SetActive ((cooldown >= 40f) ? true : false);
		s1.SetActive ((cooldown >= 20f) ? true : false);
	}

	IEnumerator Blink () {
		while (gameController.getCooldown () == 100f) {
			s5.SetActive (false);
			s4.SetActive (false);
			s3.SetActive (false);
			s2.SetActive (false);
			s1.SetActive (false);
			yield return new WaitForSeconds (0.2f);
			s5.SetActive (true);
			s4.SetActive (true);
			s3.SetActive (true);
			s2.SetActive (true);
			s1.SetActive (true);
			yield return new WaitForSeconds (0.2f);
		}
	}
}

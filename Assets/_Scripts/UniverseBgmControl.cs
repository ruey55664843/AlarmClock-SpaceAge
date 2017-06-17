using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniverseBgmControl : MonoBehaviour {
	private float fadeTime = 1; // fade time in seconds
	private AudioSource source;
	private GameController gameController;
	private bool faded = false;
	private float curVolume = 0.45f;

	void Start() {
		source = GetComponent<AudioSource> ();
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
		fadeTime = gameController.gameOverWait;
		source.volume = curVolume;
	}

	void Update () {
		if (gameController.gameStart) {
			source.Play ();
			gameController.gameStart = false;
		}
		if (gameController.gameOver && !faded) {
			FadeSound ();
			faded = true;
		}
	}

	void FadeSound() { 
		if(fadeTime == 0) { 
			source.volume = 0;
			return;
		}
		StartCoroutine(FadeBgm ()); 
	}

	IEnumerator FadeBgm() {
		float t = fadeTime;
		while (t > 0) {
			yield return null;
			t-= Time.deltaTime;
			source.volume = t/fadeTime*curVolume;
		}
		yield break;
	}
}

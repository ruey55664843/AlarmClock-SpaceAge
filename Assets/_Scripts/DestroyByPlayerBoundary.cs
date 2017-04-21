using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByPlayerBoundary : MonoBehaviour
{
	private GameController gameController;
	private int scoreValue;

	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void OnTriggerExit(Collider other)
	{
		Vector3 scaleOfHazard = other.transform.localScale;
		scoreValue = Mathf.RoundToInt (50 * scaleOfHazard.x * scaleOfHazard.y * scaleOfHazard.z / 400 / 400 / 400);
		gameController.AddScore(-2*scoreValue);
		//Debug.Log (scoreValue.ToString ());
		Destroy(other.gameObject);
	}
}

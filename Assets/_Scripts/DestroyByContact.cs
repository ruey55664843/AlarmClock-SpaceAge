using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DestroyByContact : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
	public GameObject score;
	public GameObject hazard;

	private int scoreValue = 50;
	private GameController gameController;

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

	public void OnPointerDown(PointerEventData eventData)
	{
		Vector3 scaleOfHazard = transform.localScale;
		scoreValue = Mathf.RoundToInt (50 * scaleOfHazard.x * scaleOfHazard.y * scaleOfHazard.z / 400 / 400 / 400);
		gameController.AddScore(scoreValue);
		Destroy (hazard);

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

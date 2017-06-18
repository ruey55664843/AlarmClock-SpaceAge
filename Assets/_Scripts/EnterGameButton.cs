﻿using UnityEngine;
using System.Collections;

public class EnterGameButton : MonoBehaviour {

	// How long to look at Menu Item before taking action
	public float timerDuration = 2f;

	//Indicate the fade of ring
	public bool fadeStart = false;

	// This value will count down from the duration
	private float lookTimer = 0f;

	// My renderer so I can set _Cutoff value
	private Renderer myRenderer;

	// Box Collider
	private BoxCollider myCollider;

	// Is player looking at me?
	private bool isLookedAt = false;

	private AudioSource source;

	// MonoBehaviour Start
	void Start() {
		// My Collider
		myCollider = GetComponent<BoxCollider>();
		// Get my Renderer
		myRenderer = GetComponent<Renderer>();
		// Set cutoff
		myRenderer.material.SetFloat("_Cutoff", 0f);
		source = GetComponent<AudioSource> ();
	}

	// MonoBehaviour Update
	void Update() {
		// While player is looking at me
		if (isLookedAt) {
			// Reduce Timer
			lookTimer += Time.deltaTime;

			// Set cutoff value on material to value between 0 and 1
			myRenderer.material.SetFloat("_Cutoff", lookTimer / timerDuration);

			if (lookTimer > timerDuration) {
				// Reset timer
				lookTimer = 0f;

				// disable collider
				//myCollider.enabled = false;

				// Do something
				//Debug.Log("BUTTON HAS BEEN SELECTED!");
				source.Play ();
				Application.LoadLevel ("Thor");
				//MenuController.control.AddCoins(100);

				// Disappear
				//gameObject.SetActive(false);
				fadeStart = false;
			}else if (lookTimer > timerDuration * 0.7f && !fadeStart) {
				fadeStart = true;
			}
		}  else {
			// Reset Timer
			lookTimer = 0f;
			// Reset Cutoff
			myRenderer.material.SetFloat("_Cutoff", 0f);
			fadeStart = false;
		}
	}

	// Google Cardboard Gaze
	public void SetGazedAt(bool gazedAt) {
		// Set the local bool to the one passed from Event Trigger
		isLookedAt = gazedAt;
	}
}


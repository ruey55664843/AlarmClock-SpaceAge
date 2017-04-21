using UnityEngine;
using System.Collections;

public class EnterAlarmButton : MonoBehaviour {

	// How long to look at Menu Item before taking action
	public float timerDuration = 2f;

	// This value will count down from the duration
	private float lookTimer = 0f;

	// My renderer so I can set _Cutoff value
	private Renderer myRenderer;

	// Box Collider
	private BoxCollider myCollider;

	// Is player looking at me?
	private bool isLookedAt = false;

	private AudioSource source;
	public AudioClip select;
	public AudioClip dontTouchThisButton;
	private bool selectPlayed;
	private bool dontTTBPlayed;

	public GameObject rocketRacoon;


	// MonoBehaviour Start
	void Start() {
		// My Collider
		myCollider = GetComponent<BoxCollider>();
		// Get my Renderer
		myRenderer = GetComponent<Renderer>();
		// Set cutoff
		myRenderer.material.SetFloat("_Cutoff", 0f);

		source = GetComponent<AudioSource> ();
		selectPlayed = false;
		dontTTBPlayed = false;
		//source.Play ();
		rocketRacoon.SetActive (false);
	}

	// MonoBehaviour Update
	void Update() {
		// While player is looking at me
		if (isLookedAt) {
			// Reduce Timer
			lookTimer += Time.deltaTime;

			if (MenuController.control.isRinging) {
				timerDuration = 10f;
				if (!dontTTBPlayed) {
					source.PlayOneShot (dontTouchThisButton);
					dontTTBPlayed = true;
					rocketRacoon.SetActive (true);
				}
			} else {
				timerDuration = 2f;
				rocketRacoon.SetActive (false);
			}

			// Set cutoff value on material to value between 0 and 1
			myRenderer.material.SetFloat("_Cutoff", lookTimer / timerDuration);

			if (lookTimer > timerDuration) {
				// Reset timer
				lookTimer = 0f;

				// disable collider
				//myCollider.enabled = false;

				// Do something
				//Debug.Log("BUTTON HAS BEEN SELECTED!");
				Application.LoadLevel ("Alarm");
				//MenuController.control.AddCoins(100);

				// Disappear
				//gameObject.SetActive(false);
			}else if (lookTimer > timerDuration*0.95f && !selectPlayed){
				source.PlayOneShot (select);
				selectPlayed = true;
			}

		}  else {
			// Reset Timer
			lookTimer = 0f;
			// Reset Cutoff
			myRenderer.material.SetFloat("_Cutoff", 0f);
			rocketRacoon.SetActive (false);
		}
	}

	// Google Cardboard Gaze
	public void SetGazedAt(bool gazedAt) {
		// Set the local bool to the one passed from Event Trigger
		isLookedAt = gazedAt;
	}
}


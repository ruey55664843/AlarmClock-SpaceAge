using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanishTimeout : MonoBehaviour {


	public GameObject Minion;
	public GameObject Thunder;
	public int TimeOut;
	public float killsphere;
	private Animation anim;
	private Vector3 Ray_origin;
	private Vector3 Ray_direction;
	private ClickHandler clickHandler;

	private Thor_GameControl gameController;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animation>();
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		GameObject clickHandlerObject = GameObject.FindGameObjectWithTag ("Click");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <Thor_GameControl>();
			clickHandler = clickHandlerObject.GetComponent <ClickHandler> ();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
		//StartCoroutine(CountDownExplode());
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(Camera.main.transform);
		if (gameController.ThorUltimate ()) {
			Quaternion spawnRotation = Quaternion.identity;
			GameObject spawnedHazard = Instantiate (Thunder, transform.position, spawnRotation);
			StartCoroutine(Killed());
		}
		if (clickHandler.fire) {
			Ray_origin = clickHandler.rayOrigin;
			Ray_direction = clickHandler.shootDirection;
			Vector3 va = transform.position - Ray_origin;
			Ray_direction = Camera.main.transform.forward;
			Vector3 vb = Ray_direction / Ray_direction.magnitude;
			float dist = Vector3.Cross (va, vb).magnitude;
			if (dist < killsphere)
				StartCoroutine(Killed());
		}
	}

	IEnumerator CountDownExplode (){
		yield return new WaitForSeconds(TimeOut);
		anim.Play ();
		yield return new WaitForSeconds(anim.clip.length);
		Destroy (Minion);
	}

	IEnumerator Killed (){
		anim.Play ();
		yield return new WaitForSeconds(anim.clip.length);
		Destroy (Minion);
	}
}

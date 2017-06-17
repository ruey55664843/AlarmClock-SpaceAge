using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanishTimeout : MonoBehaviour {


	public GameObject Minion;
	public int TimeOut;
	public Animation anim;
	public AnimationClip Anime_Death;
	public bool Fire;
	public Vector3 Ray_origin;
	public Vector3 Ray_direction;
	//private GameObject Camera;

	private Thor_GameControl gameController;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animation>();
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		//GameObject cameraObject = GameObject.FindGameObjectWithTag ("MainCamera");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <Thor_GameControl>();
			//Camera = cameraObject;
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
			anim.Play();
			Destroy (Minion);
		}
		if (Fire) {
			Vector3 va = transform.position - Ray_origin;
			Ray_direction = Camera.main.transform.forward;
			Vector3 vb = Ray_direction / Ray_direction.magnitude;
			float dist = Vector3.Cross (va, vb).magnitude;
			if (dist < 6.0f)
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

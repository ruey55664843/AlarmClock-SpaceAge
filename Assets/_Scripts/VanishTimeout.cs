using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanishTimeout : MonoBehaviour {


	public GameObject Minion;
	public int TimeOut;

	// Use this for initialization
	void Start () {
		StartCoroutine(SelfDestruct());
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(Camera.main.transform);
	}

	IEnumerator SelfDestruct (){
		yield return new WaitForSeconds(TimeOut);
		Destroy (Minion);
	}
}

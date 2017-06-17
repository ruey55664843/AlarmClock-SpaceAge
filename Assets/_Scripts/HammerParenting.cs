using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerParenting : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.localPosition = new Vector3 (1.939808f, -1.965572f, 1.928397f);
		transform.parent = Camera.main.transform;
		Debug.Log ("Set local position!");
	}
	void Update () {
		
	}
}

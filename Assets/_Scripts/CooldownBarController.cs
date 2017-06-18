using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownBarController : MonoBehaviour {

	public GameObject s1;
	public GameObject s2;
	public GameObject s3;
	public GameObject s4;
	public GameObject s5;

	public float cooldown;

	void Start () {
		UpdateCooldownStatus (100f);
	}

	void Update () {
		UpdateCooldownStatus (cooldown);
	}

	void UpdateCooldownStatus (float cooldown){
		s5.SetActive ((cooldown >= 100f) ? true : false);
		s4.SetActive ((cooldown >= 80f) ? true : false);
		s3.SetActive ((cooldown >= 60f) ? true : false);
		s2.SetActive ((cooldown >= 40f) ? true : false);
		s1.SetActive ((cooldown >= 20f) ? true : false);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarController : MonoBehaviour {

	public GameObject r1;
	public GameObject o1;
	public GameObject o2;
	public GameObject o3;
	public GameObject y1;
	public GameObject y2;
	public GameObject y3;
	public GameObject g1;
	public GameObject g2;
	public GameObject g3;

	public float health;

	void Start () {
		UpdateHealthStatus (100f);
	}

	void Update () {
		UpdateHealthStatus (health);
	}

	void UpdateHealthStatus (float health){
		g3.SetActive ((health >= 90f) ? true : false);
		g2.SetActive ((health >= 80f) ? true : false);
		g1.SetActive ((health >= 70f) ? true : false);
		y3.SetActive ((health >= 60f) ? true : false);
		y2.SetActive ((health >= 50f) ? true : false);
		y1.SetActive ((health >= 40f) ? true : false);
		o3.SetActive ((health >= 30f) ? true : false);
		o2.SetActive ((health >= 20f) ? true : false);
		o1.SetActive ((health >= 10f) ? true : false);
		r1.SetActive ((health >= 0f) ? true : false);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thor_GameControl : MonoBehaviour {

	public GameObject IceGolem;
	public GameObject Goblin;
	public bool gameOver;
	public float volTh;
	public AudioClip thundersound;

	private bool Ragnarok;//private
	private bool UltAvailable;
	private int GoblinNum;
	private int GolemNum;
	private MicInput[] mic;
	private AudioSource source;


	// Use this for initialization
	void Start () {
		gameOver = false;
		Ragnarok = false;
		UltAvailable = true;
		mic = Camera.main.GetComponents <MicInput> ();

		StartCoroutine (SpawnWaves ());
		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (mic[0].getLoudness() >= volTh && UltAvailable){
			UltAvailable = false;
			Ragnarok = true;
			source.Play ();
			StartCoroutine (WaitForThunder ());
		}
	}

	IEnumerator WaitForThunder (){
		yield return new WaitForSeconds (5);
		Ragnarok = false;
		source.Stop ();
		yield return new WaitForSeconds (25);
		UltAvailable = true;
	}

	public bool ThorUltimate (){
	   return Ragnarok;
	}

	IEnumerator SpawnWaves (){
		GoblinNum = Random.Range (10, 14);
		GolemNum = Random.Range (1, 3);
		for (int times = 0; times <= 100; times++) {
			for (int i = 0; i < GoblinNum; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-75, 75), 8, Random.Range (-75, 75));
				Quaternion spawnRotation = Quaternion.identity;
				GameObject spawnedHazard = Instantiate (Goblin, spawnPosition, spawnRotation);
			}
			for (int i = 0; i < GolemNum; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-75, 75), 8, Random.Range (-75, 75));
				Quaternion spawnRotation = Quaternion.identity;
				GameObject spawnedHazard = Instantiate (IceGolem, spawnPosition, spawnRotation);
			}
			yield return new WaitForSeconds (3);
		}
	}
}

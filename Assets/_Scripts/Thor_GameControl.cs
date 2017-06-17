using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thor_GameControl : MonoBehaviour {

	public GameObject IceGolem;
	public GameObject Goblin;
	public bool gameOver;

	private bool Ragnarok;
	private int GoblinNum;
	private int GolemNum;


	// Use this for initialization
	void Start () {
		gameOver = false;
		Ragnarok = true;
		StartCoroutine (SpawnWaves ());
		
	}
	
	// Update is called once per frame
	void Update () {
		
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

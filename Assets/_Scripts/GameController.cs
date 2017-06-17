using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
	public GameObject hazard;
	public float universeRadius;
	public float guideWait;
	public float countDownWait;
	public float waveWait;
	public float gameOverWait;
	public Text scoreText;
	public AudioClip explosion;
	public AudioClip countdownRelax;
	public AudioClip countdownTense;
	public Text gameText;
	public Text overText;
	public bool gameOver;
	public bool gameStart;
	public GameObject extremeModeBoundary;
	public GameObject starlord;

	//private GameObject spawnedHazard;
	private AudioSource source;
	private AudioClip countdown;
	private float x, y, z;
	private float theta, phi;
	private int score;
	private string today = System.DateTime.Now.Date.ToString ();
	private float recordTime = 0f;
	private bool timeOut = false;
	private int passScore;
	private int hazardCount;


	//int coins;

	void Start ()
	{
		gameStart = false;
		gameOver = false;
		gameText.text = "blow up";
		overText.text = "asteroids !";
		score = 0;
		UpdateScore ();
		if (MenuController.control.gameMode == 1) {
			extremeModeBoundary.SetActive (true);
			passScore = 350;
			countdown = countdownTense;
			hazardCount = 6;
			waveWait = 4f;
		} else {
			extremeModeBoundary.SetActive (false);
			passScore = 200;
			countdown = countdownRelax;
			hazardCount = 5;
			waveWait = 5f;
		}
		source = GetComponent<AudioSource> ();
		source.PlayOneShot (countdown);
		starlord.SetActive (false);
		StartCoroutine (SpawnWaves ());
	}

	void Update ()
	{
		if (score >= passScore && !gameOver) {
			GameOver ();
		} else if (recordTime >= 120 && !gameOver){
			timeOut = true;
			GameOver ();
		}else if (!gameOver){
			recordTime += Time.deltaTime;
		}
	}

	/*void OnDestroy ()
	{
		coins += 100;
		PlayerPrefs.SetInt ("totalCoins", coins);
	}*/

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (guideWait);
		gameText.text = "earn over";
		overText.text = passScore.ToString () + " pts !!!";
		source.PlayOneShot (countdown);
		yield return new WaitForSeconds (guideWait);
		gameText.text = "";
		overText.text = "3";
		source.PlayOneShot (countdown);
		yield return new WaitForSeconds (countDownWait);
		overText.text = "2";
		source.PlayOneShot (countdown);
		yield return new WaitForSeconds (countDownWait);
		overText.text = "1";
		source.PlayOneShot (countdown);
		yield return new WaitForSeconds (countDownWait);
		overText.text = "";
		source.PlayOneShot (countdown);
		recordTime = 0f;
		gameStart = true;
		while (true)
		{
			for (int i = 0; i < hazardCount; i++) 
			{
				theta = Random.Range (1.04f, 2.09f); //60~120 degrees
				phi = Random.Range (0, Mathf.PI*2f);  //0~180degrees
				x = universeRadius * Mathf.Sin (theta) * Mathf.Cos (phi);
				z = universeRadius * Mathf.Sin (theta) * Mathf.Sin (phi);
				y = universeRadius * Mathf.Cos (theta);
				Vector3 spawnPosition = new Vector3 (x, y, z);
				Quaternion spawnRotation = Quaternion.identity;
				GameObject spawnedHazard = Instantiate (hazard, spawnPosition, spawnRotation);
				Vector3 originalScale = hazard.transform.localScale;
				Vector3 temp;
				temp.x = originalScale.x * Random.Range (0.5f, 1f);
				temp.y = originalScale.y * Random.Range (0.5f, 1f);
				temp.z = originalScale.z * Random.Range (0.5f, 1f);
				spawnedHazard.transform.localScale = temp;

				if (gameOver)
				{
					yield return new WaitForSeconds (gameOverWait);
					break;
				}
			}
			if (gameOver) {
				break;
			} else {
				yield return new WaitForSeconds (waveWait);
			}
		}
		MenuController.control.AddCoins (score);

		Application.LoadLevel ("Home");
	}

	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
		source.PlayOneShot (explosion);
	}

	public void MinusScore (int newScoreValue)
	{
		score -= newScoreValue;
		UpdateScore ();
		source.PlayOneShot (explosion);
	}

	void UpdateScore ()
	{
		scoreText.text = "Score: " + score;
	}

	public void GameOver ()
	{
		if (!timeOut) {
			if (MenuController.control.gameMode == 1) {
				gameText.text = "Game Over";
				overText.text = "  Congrats !";
				starlord.SetActive (true);
			} else {
				gameText.text = "Game";
				overText.text = "Over";
			}
			MenuController.control.shootRecords.Add (new ShootRecord (today, recordTime));
			MenuController.control.shootRecords.Sort ();
			//Debug.Log ("Date1: " + MenuController.control.shootRecords [1].date +"Time1: " + MenuController.control.shootRecords [1].time +"Count: " + MenuController.control.shootRecords.Count.ToString ());
		}else{
			gameText.text = "Game";
			overText.text = "Failure";
		}
		gameOver = true;
	}
}
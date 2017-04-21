using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardRender : MonoBehaviour {
	public TextMesh coinText;
	public TextMesh alarmText;
	public TextMesh curTimeText;
	public AudioClip starwar;

	private float fadeTime = 1; // fade time in seconds
	private int nowHour, nowMinute, nowAmPm;
	private int alarmHour, alarmMinute, alarmAmPm;
	private string hourString, minuteString, amPmString;
	private int coin;
	private AudioSource source;
	private bool ringed = false;
	private EnterGameButton enterGameButton;
	private bool faded = false;
	private int curVolume = 1;

	void Start () {
		coin = MenuController.control.coins;
		coinText.text = "Coins: " + coin.ToString ();
		source = GetComponent<AudioSource> ();
		GameObject enterGameButtonObject = GameObject.FindGameObjectWithTag ("GameButton");
		if (enterGameButtonObject != null)
		{
			enterGameButton = enterGameButtonObject.GetComponent <EnterGameButton>();
		}
		if (enterGameButton == null)
		{
			Debug.Log ("Cannot find 'EnterGameButton' script");
		}
		fadeTime = enterGameButton.timerDuration / 2f;
	}

	void Update ()
	{
		CheckAlarm ();
	}

	void CheckAlarm ()
	{
		alarmHour = MenuController.control.hour;
		alarmMinute = MenuController.control.minute;
		alarmAmPm = MenuController.control.amPm;
		ringed = MenuController.control.ringed;
		nowHour = System.DateTime.Now.Hour;
		if (nowHour >= 12) {
			nowHour -= 12;
			nowAmPm = 1;
			amPmString = "PM";
		} else {
			nowAmPm = 0;
			amPmString = "AM";
		}
		//add 0 when number<10
		if (nowHour < 10) {
			hourString = "0" + nowHour.ToString ();
		} else {
			hourString = nowHour.ToString ();
		}
		nowMinute = System.DateTime.Now.Minute;
		if (nowMinute < 10) {
			minuteString = "0" + nowMinute.ToString ();
		} else {
			minuteString = nowMinute.ToString ();
		}

		//display current time
		curTimeText.text = hourString + ":" + minuteString + " " + amPmString;

		//alarm clock play music
		if (nowHour == alarmHour && nowAmPm == alarmAmPm && nowMinute == alarmMinute) {
			if (!ringed) {
				source.PlayOneShot (starwar);
				source.volume = curVolume;
				ringed = true;
				MenuController.control.ringed = ringed;
			}
		}

		//detect ringing sound
		if (source.isPlaying) {
			alarmText.text = "Ring !!!";
			MenuController.control.isRinging = true;
		} else {
			alarmText.text = "Sleep...";
			MenuController.control.isRinging = false;
		}

		if (enterGameButton.fadeStart && !faded) {
			FadeSound ();
			faded = true;
		}
	}

	void FadeSound() { 
		if(fadeTime == 0) { 
			source.volume = 0;
			return;
		}
		StartCoroutine(FadeBgm ()); 
	}

	IEnumerator FadeBgm() {
		float t = fadeTime;
		while (t > 0) {
			yield return null;
			t-= Time.deltaTime;
			source.volume = t/fadeTime*curVolume;
		}
		yield break;
	}
}

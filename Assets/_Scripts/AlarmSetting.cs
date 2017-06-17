using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmSetting : MonoBehaviour {
	public TextMesh hourText;
	public TextMesh minuteText;
	public TextMesh amPmText;


	private int hour, minute, amPm;
	private string hourString, minuteString, amPmString;

	void Update ()
	{
		hour = MenuController.control.hour;
		minute = MenuController.control.minute;
		amPm = MenuController.control.amPm;

		SetTime ();
	}

	void SetTime ()
	{
		if (hour < 10) {
			hourString = "0" + hour.ToString ();
		} else {
			hourString = hour.ToString ();
		}

		if (minute < 10) {
			minuteString = "0" + minute.ToString ();
		} else {
			minuteString = minute.ToString ();
		}

		if (amPm == 0) {
			amPmString = "AM";
		} else {
			amPmString = "PM";
		}
		hourText.text = hourString;
		minuteText.text = minuteString;
		amPmText.text = amPmString;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class MenuController : MonoBehaviour {
	public static MenuController control;
	//public Text textCoins;
	public int hour = 0;
	public int minute = 0;
	public int amPm = 0;		// am=0, pm=1
	public bool ringed = false;
	public int gameMode = 0;	//normal=0, extreme=1;
	public List<ShootRecord> shootRecords = new List<ShootRecord> ();

	public bool isRinging = false;

	//public TextMesh alarmText;

	//private int nowHour, nowMinute, nowAmPm;
	void OnEnable (){
		Load ();
		//shootRecords.Add (new ShootRecord ("1", 1f));
	}

	void Awake (){
		if (control == null) {
			DontDestroyOnLoad (gameObject);
			control = this;
		} else if (control != this) {
			Destroy (gameObject);
		}
	}

	void Update (){
		/*Debug.Log ("Date1: " + shootRecords [0].date +"Time1: " 
			+ shootRecords [0].time 
			+"Count: " + shootRecords.Count.ToString ());*/
	}

	void OnDisable (){
		Save ();
	}

	public void Save ()
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/playerInfo.dat");

		PlayerData data = new PlayerData ();
		data.hour = hour;
		data.minute = minute;
		data.amPm = amPm;
		data.gameMode = gameMode;
		data.ringed = false;	//next open should ring
		data.shootRecords = shootRecords;

		bf.Serialize (file, data);
		bf.Serialize (file, shootRecords);
		file.Close ();
	}

	public void Load ()
	{
		if (File.Exists (Application.persistentDataPath + "/playerInfo.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/playerInfo.dat",FileMode.Open);
			PlayerData data = (PlayerData)bf.Deserialize (file);
			List<ShootRecord> shoorRecords = (List<ShootRecord>)bf.Deserialize (file);
			file.Close ();
			hour = data.hour;
			minute = data.minute;
			amPm = data.amPm;
			gameMode = data.gameMode;
			ringed = data.ringed;
			shootRecords = data.shootRecords;
		}
	}
}

[Serializable]
class PlayerData
{
	public int hour = 0;
	public int minute = 0;
	public int amPm = 0;
	public int gameMode = 0;
	public bool ringed = false;
	public List<ShootRecord> shootRecords = new List<ShootRecord> ();

}

[Serializable]
public class ShootRecord : IComparable<ShootRecord>
{
	public string date;
	public float time;

	public ShootRecord(string newDate, float newTime)
	{
		date = newDate;
		time = newTime;
	}

	//This method is required by the IComparable
	//interface. 
	public int CompareTo(ShootRecord other)
	{
		if(other == null)
		{
			return 1;
		}

		//Return the difference in power.
		return Mathf.RoundToInt(time - other.time);
	}
}
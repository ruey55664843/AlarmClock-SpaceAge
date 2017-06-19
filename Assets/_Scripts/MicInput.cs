﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MicInput : MonoBehaviour {

	private float MicLoudness;
	//public TextMesh volumeText;
	private string _device;
	private int minFreq;
	private int maxFreq;

	public float getLoudness (){
		return MicLoudness;
	}

	//mic initialization
	void InitMic(){
		if(_device == null) _device = Microphone.devices[0];
		//volumeText.text = "";
		//volumeText.text = _device;
		Microphone.GetDeviceCaps(null, out minFreq, out maxFreq);
		if(minFreq == 0 && maxFreq == 0)  
		{  
			maxFreq = 44100;
		}
		//volumeText.text = _device + " " + maxFreq.ToString ();
		_clipRecord = Microphone.Start(_device, true, 999, maxFreq);
	}

	void StopMicrophone()
	{
		Microphone.End(_device);
	}


	AudioClip _clipRecord = new AudioClip();
	int _sampleWindow = 128;

	//get data from microphone into audioclip
	float  LevelMax()
	{
		float levelMax = 0;
		float[] waveData = new float[_sampleWindow];
		int micPosition = Microphone.GetPosition(null)-(_sampleWindow+1); // null means the first microphone
		//volumeText.text = micPosition.ToString ();
		if (micPosition < 0) {
			/*if (Application.HasUserAuthorization(UserAuthorization.Microphone)) {
				volumeText.text = "Has permission! No input!";
			} else {
				volumeText.text = "No permission! No input";
			}*/
			return 0;
		}
		//volumeText.text = "get input!";
		_clipRecord.GetData(waveData, micPosition);
		// Getting a peak on the last 128 samples
		for (int i = 0; i < _sampleWindow; i++) {
			float wavePeak = waveData[i] * waveData[i];
			if (levelMax < wavePeak) {
				levelMax = wavePeak;
				/*if (volumeText.text == "Volume") {
					volumeText.text = "get data";
				}*/
			}
		}
		return levelMax;
	}



	void Update()
	{
		// levelMax equals to the highest normalized value power 2, a small number because < 1
		// pass the value to a static var so we can access it from anywhere
		MicLoudness = LevelMax ();
		//volumeText.text = MicLoudness.ToString ();
	}

	bool _isInitialized;
	// start mic when scene starts
	/*void OnEnable()
	{
		InitMic();
		_isInitialized=true;
	}*/

	private IEnumerator Start (){
		if(Application.platform == RuntimePlatform.Android)
			yield return Application.RequestUserAuthorization(UserAuthorization.Microphone);
		if (Application.HasUserAuthorization(UserAuthorization.Microphone)) {
			//volumeText.text = "Has permission!";
		} else {
			//volumeText.text = "No permission!";
		}
		InitMic();
		_isInitialized=true;
	}

	//stop mic when loading a new level or quit application
	void OnDisable()
	{
		StopMicrophone();
	}

	void OnDestroy()
	{
		StopMicrophone();
	}


	// make sure the mic gets started & stopped when application gets focused
	void OnApplicationFocus(bool focus) {
		if (focus)
		{
			//Debug.Log("Focus");

			if(!_isInitialized){
				//Debug.Log("Init Mic");
				InitMic();
				_isInitialized=true;
			}
		}      
		if (!focus)
		{
			//Debug.Log("Pause");
			StopMicrophone();
			//Debug.Log("Stop Mic");
			_isInitialized=false;

		}
	}
}
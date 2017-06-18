using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingBoardRender : MonoBehaviour {

	public TextMesh firstPlaceText;
	public TextMesh secondPlaceText;
	public TextMesh thirdPlaceText;

	private float first = 0f, second = 0f, third = 0f;

	void Start (){
		if (MenuController.control.shootRecords.Count > 0) {
			first = MenuController.control.shootRecords [0].time;
		}
		if (MenuController.control.shootRecords.Count > 1) {
			second = MenuController.control.shootRecords [1].time;
		}
		if (MenuController.control.shootRecords.Count >2 ) {
			third = MenuController.control.shootRecords [2].time;
		}
		firstPlaceText.text = "";
		secondPlaceText.text = "";
		thirdPlaceText.text = "";
		RenderRankings ();
	}

	void Update(){ //
		if (MenuController.control.shootRecords.Count == 0) {
			firstPlaceText.text = "";
			secondPlaceText.text = "";
			thirdPlaceText.text = "";
		}
	}

	void RenderRankings (){
		if (first != 0f) {
			firstPlaceText.text = "1. " + first.ToString ("#.00") + " pts.";
		}
		if (second != 0f) {
			secondPlaceText.text = "2. " + second.ToString ("#.00") + " pts.";
		}
		if (third != 0f) {
			thirdPlaceText.text = "3. " + third.ToString ("#.00") + " pts.";
		}
	}

}

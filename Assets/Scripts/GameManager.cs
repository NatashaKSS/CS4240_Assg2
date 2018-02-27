using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public GameObject WinningText;

	private int score;
	private int shotsFired;

	// Use this for initialization
	void Start () {
		score = 0;
		shotsFired = 0;
		SetWinningText();
	}

	public int GetScore() {
		return score;
	}

	public void SetScore(int val) {
		score = val;
	}

	public int GetShotsFired() {
		return shotsFired;
	}

	public void SetShotsFired(int val) {
		shotsFired = val;
	}

	public void SetWinningText() {
		if (score >= 3) {
			WinningText.transform.GetComponent<Text> ().text = "You win!";
		} else {
			if (shotsFired >= 3) {
				WinningText.transform.GetComponent<Text> ().text = "Yikes! No bullets left. Restart the game and try again!";
			} else {
				WinningText.transform.GetComponent<Text> ().text = "Keep shooting! Try to hit all the targets.";
			}
		}
	}

}

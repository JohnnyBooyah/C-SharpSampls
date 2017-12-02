using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

	public GUIText ScoreText;
	private int score;
	// Use this for initialization
	void Start () {
		score -= 100;
		UpdateScore ();
	}

	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	// Update is called once per frame
	void UpdateScore () {
		ScoreText.text = "Score: " + score;
	}
}

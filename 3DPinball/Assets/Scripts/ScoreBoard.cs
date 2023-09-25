using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Text))]
public class ScoreBoard : MonoBehaviour {
	
	private int totalScore;

	private Text text;

	void Start () {
		text = GetComponent<Text> ();
	}

	void ApplyPoint(int score) {
		totalScore += score;
		text.text = "Score:" + totalScore;
	}
}

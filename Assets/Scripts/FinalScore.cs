using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FinalScore : MonoBehaviour {

	public static Text bestScore;

	// Use this for initialization
	void Start () {
		Text finalScore = GetComponent<Text>();
		finalScore.text = "Score: " + ScoreManager.grandTotal.ToString ();		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

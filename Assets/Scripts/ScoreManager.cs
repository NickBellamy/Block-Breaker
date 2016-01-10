using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	public Text combo;
	public Text tempScore;
	public Text totalScore;
	public static int currentCombo = 0;
	public static int currentScore = 0;
	public static int grandTotal = 0;
	
	private void Start() {
	//TODO Fix errors caused on start screen from below code
		combo = GameObject.Find("Combo").GetComponent<Text>();
		tempScore = GameObject.Find("TempScore").GetComponent<Text>();
		totalScore = GameObject.Find ("TotalScore").GetComponent<Text>();

	}
	
	public void BrickDestroyed2 (int brickScore) {
		currentCombo++;
		currentScore += brickScore;
		UpdateCombo();
	}
	
	public void ComboBreaker() {
		grandTotal += (currentCombo * currentScore);
		currentCombo = 0;
		currentScore = 0;
		UpdateCombo();
	}
	
	public void UpdateCombo() {
		combo.text = "x" + currentCombo.ToString ();
		tempScore.text = currentScore.ToString();
		totalScore.text = grandTotal.ToString();
	}
	
	public void ResetScore() {
		currentCombo = 0;
		currentScore = 0;
		grandTotal = 0;
		UpdateCombo();
	}
	
}

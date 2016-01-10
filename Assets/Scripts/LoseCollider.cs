using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	private LevelManager levelManger;
	private ScoreManager scoreManager;
	
	void OnTriggerEnter2D (Collider2D collider) {
		scoreManager =  FindObjectOfType<ScoreManager>();
		scoreManager.ComboBreaker();
		levelManger = FindObjectOfType<LevelManager>();
		levelManger.LoadLevel("Lose Screen");
	}
	void OnCollisionEnter2D (Collision2D collision) {
		print("Collision");
	}
}

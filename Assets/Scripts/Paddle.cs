﻿using UnityEngine;
using System.Collections;
public class Paddle : MonoBehaviour {

	public bool autoPlay = false;
	public float minX, maxX;
	
	private Ball ball;
	private ScoreManager scoreManager;
	
	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
		scoreManager = GameObject.FindObjectOfType<ScoreManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!autoPlay) {
			MoveWithMouse();
		} else {
			AutoPlay();
		}
	}
	
	void AutoPlay() {
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		float ballPosInBlocks = ball.transform.position.x;
		paddlePos.x = Mathf.Clamp(ballPosInBlocks, minX, maxX);
		this.transform.position = paddlePos;
	}
	
	void MoveWithMouse () {
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		paddlePos.x = Mathf.Clamp(mousePosInBlocks, minX, maxX);
		this.transform.position = paddlePos;
	}
	
	void OnCollisionEnter2D (Collision2D col) {
		scoreManager.ComboBreaker();
	}
}
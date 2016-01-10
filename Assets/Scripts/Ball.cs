using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	private Paddle paddle;
	private bool hasStarted = false;
	private Vector3 paddleToBallVector;
	
	// Use this for initialization
	void Start () {
		paddle = FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(!hasStarted) {
			//Lock the ball relative to the paddle
			this.transform.position = paddle.transform.position + paddleToBallVector;
			
			//Wait for a mouse press to launch
			if(Input.GetMouseButtonDown(0)) {
				print ("Mouse Clicked, launching ball!");
				hasStarted=true;
				this.rigidbody2D.velocity = new Vector2(2f, 8.5f);
			}
		}
	}
	
	void OnCollisionEnter2D (Collision2D collision) {
	
		if (hasStarted) {
		
			//Set variables.  "tweak" vector has component to gradually increase speed of the ball
		
			Vector2 tweak = new Vector2 (0,-0.01f);
			float maxSpeed = 16;
			float minSpeed = rigidbody2D.velocity.magnitude;
			
			//Tweak velocity if x component of velocity is negliagable
			
			if (Mathf.Pow(rigidbody2D.velocity.x, 2) < 0.5) {
				tweak.x += Random.Range(-0.5f, 0.5f);
				print ("X tweak!");
			}
			
			//Tweak velocity if x component of velocity is negliagable
			
			if (Mathf.Pow(rigidbody2D.velocity.y, 2) < 0.5) {
				tweak.y += Random.Range(-0.5f, 0.5f);
				print ("Y tweak!");
			}
			
			//Add tweak to ball velocity
			
			rigidbody2D.velocity += tweak;

			//Make sure ball's velocity magnitude is at least minSpeed
			
			if (rigidbody2D.velocity.magnitude < minSpeed) {
				rigidbody2D.velocity = (rigidbody2D.velocity.normalized * minSpeed);
			}
			
			//Cap ball speed at maxSpeed
			
			rigidbody2D.velocity = Vector2.ClampMagnitude(rigidbody2D.velocity, maxSpeed);
			
			//Set minSpeed to new ball velocity
			
			minSpeed = rigidbody2D.velocity.magnitude;
			
			audio.Play ();
		}
	}
}

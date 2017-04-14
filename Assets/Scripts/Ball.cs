using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	private Paddle paddle;
	private bool hasLaunched = false;
	private Vector3 paddleToBallVector;

	public bool HasLaunched {
		get{ return hasLaunched; }
	}

	// Use this for initialization
	void Start() {
		paddle = FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update() {
		if (!hasLaunched) {
			// Lock the ball relative to the paddle
			this.transform.position = paddle.transform.position + paddleToBallVector;

			// Wait for a mouse press to launch
			if (Input.GetMouseButtonDown (0)) {
				hasLaunched = true;
				GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
			}
		}
	}

	void OnCollisionExit2D(Collision2D collision) {
		Vector2 tweak = new Vector2(Random.Range(-0.2f, 0.2f), Random.Range(0f, 0.2f));
		if (hasLaunched) {
			GetComponent<Rigidbody2D>().velocity += tweak;
		}
	}
}

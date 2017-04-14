using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	public float minX, maxX;
	public bool autoPlay = false;

	private Ball ball;

	// Use this for initialization
	void Start() {
		ball = FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update() {
		if (autoPlay) {
			AutoPlay();
		}
		else {
			MoveWithMouse();
		}
	}

	void MoveWithMouse() {
		float mouseXInBlocks = Mathf.Clamp(Input.mousePosition.x / Screen.width * 16, minX, maxX);
		this.transform.position = new Vector3(mouseXInBlocks, this.transform.position.y);
	}

	void AutoPlay() {
		float ballXInBlocks = Mathf.Clamp(ball.transform.position.x - 0.5f, minX, maxX);
		this.transform.position = new Vector3(ballXInBlocks, this.transform.position.y);
	}

	void OnCollisionExit2D(Collision2D collision) {
		if (ball.HasLaunched) {
			GetComponent<AudioSource>().Play();
		}
	}
}

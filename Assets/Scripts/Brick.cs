using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	public Sprite[] hitSprites;
	public AudioClip crack;
	public GameObject smoke;

	private static int breakableCount = 0;

	private int timesHit;
	private bool isBreakable;
	private LevelManager levelManager;

	public static void ResetBreakableCount() {
		breakableCount = 0;
	}

	// Use this for initialization
	void Start() {
		timesHit = 0;
		isBreakable = (this.tag == "Breakable");
		// Keep track of breakable bricks
		if (isBreakable) {
			breakableCount++;
		}
		levelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update() {
		
	}

	void OnCollisionExit2D(Collision2D col) {
		AudioSource.PlayClipAtPoint(crack, transform.position, 0.8f);
		if (isBreakable) {
			HandleHits();
		}
	}

	void HandleHits() {
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits) {
			breakableCount--;
			CreateSmokePuff();
			Destroy(gameObject);

			// if all bricks have been destroyed, go to next level
			if (breakableCount <= 0) {
				levelManager.LoadNextLevel();
			}
		}
		else {
			LoadSprites();
		}
	}

	void CreateSmokePuff() {
		Vector3 position = transform.position;
		position.x += .5f;
		position.y += .16f;
		GameObject smokePuff = Instantiate(smoke, position, Quaternion.identity);
		ParticleSystem.MainModule main = smokePuff.GetComponent<ParticleSystem>().main;
		main.startColor = GetComponent<SpriteRenderer>().color;
	}

	void LoadSprites() {
		int spriteIndex = timesHit - 1;
		if (hitSprites[spriteIndex]) {
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites[spriteIndex];
		}
	}

	void SimulateWin() {
		levelManager.LoadNextLevel();
	}
}

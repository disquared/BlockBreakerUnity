using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

	static MusicPlayer instance = null;

	void Awake() {
		if (instance != null) {
			Destroy (gameObject);
			print ("Destroying gameObject");
		}
		else {
			instance = this;
			GameObject.DontDestroyOnLoad (gameObject);
		}
	}
}

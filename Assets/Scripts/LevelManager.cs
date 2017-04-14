using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name){
		Debug.Log("New Level load: " + name);
		Brick.ResetBreakableCount();
		SceneManager.LoadScene(name);
	}

	public void LoadNextLevel() {
		Brick.ResetBreakableCount();
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void QuitRequest(){
		Debug.Log("Quit requested");
		Application.Quit();
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	private Quiz quiz;
	// Use this for initialization
	void Start () {
		SceneManager.LoadScene ("Quiz");
	}
	
	// Update is called once per frame
	void Update () {
		if (quiz.IsFinished == true) {
			SceneManager.LoadScene ("Dialogue1");
			quiz.IsFinished = false;
		}
	}
}

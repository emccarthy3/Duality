using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class RhythmController : MonoBehaviour {

	// list should randomize every time
	// the list should have as many spots as the character has hp
	// the constants are the numbers that correspond to the directions
	// "lrud" means left, right, up, down
	// whichDir determines which directional key is being hit 
	private const int LEFT = 1;
	private const int RIGHT = 2;
	private const int UP = 3;
	private const int DOWN = 4;
	List<float> lrud  = new List<float>() {LEFT, RIGHT, UP, DOWN, DOWN, UP, LEFT, RIGHT, UP, DOWN};
	private int whichDir = 0;
	public Transform note; 

	// when the coroutine has begun
	private string hasBegun = "n";

	// location of the note on the background 
	private float xPos;

	void Start () {
		this.gameObject.SetActive (false);

	}

	// starts coroutine
	void Update () {
		

		if (hasBegun == "n") {
			StartCoroutine (makeNotes ());
			hasBegun = "y";

		}

	}

	// instantiates notes in the correct position on thet background
	IEnumerator makeNotes() {
		// wait one second before making a new one; this should change as the levels get harder/RP goes down
		// somewhere the gravity should be changed as levels get harder
		yield return new WaitForSeconds (1);

		if (lrud [whichDir] == 1) {
			xPos = .6f;
		}
		if (lrud [whichDir] == 2) {
			xPos = 1.8f;
		}
		if (lrud [whichDir] == 3) {
			xPos = -2.2f;
		}
		if (lrud [whichDir] == 4) {
			xPos = -0.7f;
		}
		whichDir += 1;

		hasBegun = "n";
		//if (whichDir >= lrud.Count) {
		//	hasBegun = "n";
			//this.gameObject.SetActive (false);
			//make this vanish SceneManager.LoadScene ("newBattle");
		//}

		Instantiate (note, new Vector3(xPos, 6.0f, -1f), note.rotation); 
	}

	public void Work() {

		this.gameObject.SetActive (true);

	}
}


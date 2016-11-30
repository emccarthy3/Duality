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
	private Dictionary<int, float> notePositions;
	List<int> lrud  = new List<int> {LEFT, RIGHT, UP, DOWN, DOWN, UP, LEFT, RIGHT, UP, DOWN};
	private int whichDir = 0;
	public Transform note; 
	private GameObject rb;
	private static int score;
	[SerializeField] private UIController uiController;
	// when the coroutine has begun
	private string hasBegun = "y";

	// location of the note on the background 
	private float xPos;

	void Start () {
		rb = GameObject.Find ("rhythmBackground");
		rb.gameObject.SetActive (false);
		//this.gameObject.SetActive (false);
		notePositions = new Dictionary<int, float>();
		notePositions.Add (1, .6f);
		notePositions.Add (2, 1.8f);
		notePositions.Add (3, -2.2f);
		notePositions.Add (4, -.7f);
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
		xPos = notePositions [lrud[whichDir]];
		whichDir += 1;
		if (whichDir >= lrud.Count) {
			yield return new WaitForSeconds (2.5f);
			rb.gameObject.SetActive (false);
			GameObject uic = GameObject.Find ("UIController");
			UIController uiController = uic.GetComponent <UIController> ();
			uiController.teamAttackisFinished (score);
			uiController.ChangeCanvasState (true);
		}
		else{
		hasBegun = "n";	
		Instantiate (note, new Vector3(xPos, 6.0f, -1f), note.rotation); 

		
		}
	}

	public void Work() {
		hasBegun = "n";
		rb.gameObject.SetActive (true);

	}
	public int Score {
		get{return score;}
		set{ score = value; }

	}
}


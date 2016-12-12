using UnityEngine;
using System.Collections;

public class NoteScript : MonoBehaviour {

	// the total of the points
	private int score;
	[SerializeField] private RhythmController rc;
	private GameObject gc;
	private GameController gameController;
	void Start(){
		gc = GameObject.Find ("GameController");
		gameController= gc.GetComponent <GameController> ();
		Debug.Log (gameController.YourPlayer.RP);
		Physics2D.gravity = new Vector3(0,-(100-gameController.YourPlayer.RP) , 0);
	}
	void OnTriggerEnter2D (Collider2D col) {
		
		// if the note hits the nozone, it is a missed note
		if (col.gameObject.tag == "fail") {
			Destroy (this.gameObject);
		}

		// if the note hits the arrow and it's trigger is on, you get the point!
		if (col.gameObject.tag == "arrow" && (col.gameObject.GetComponent(typeof(Collider2D)) as Collider2D).isTrigger == true) {
			Destroy (this.gameObject);
			rc.Score += 1;
		}
	
	}


}
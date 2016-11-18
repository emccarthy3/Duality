using UnityEngine;
using System.Collections;

public class NoteScript : MonoBehaviour {

	// the total of the points
	private int score;

	void OnTriggerEnter2D (Collider2D col) {
		// if the note hits the nozone, it is a missed note
		if (col.gameObject.tag == "fail") {
			Destroy (this.gameObject);
			//Debug.Log ("destroyed");
		}

		// if the note hits the arrow and it's trigger is on, you get the point!
		if (col.gameObject.tag == "arrow" && (col.gameObject.GetComponent(typeof(Collider2D)) as Collider2D).isTrigger == true) {
			Destroy (this.gameObject);
			//Debug.Log ("point");
			score++;

		}
	
	}
	public int Score {
		get{ return score; }
		set{ score = value; }
	}

}
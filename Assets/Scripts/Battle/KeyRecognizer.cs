using UnityEngine;
using System.Collections;

public class KeyRecognizer : MonoBehaviour {

	public KeyCode press;

	// Update is called once per frame
	void Update () {

		// turns on the trigger when you press the corresponding key, turns it off when you pull up 
		if (Input.GetKeyDown (press)) {
			(gameObject.GetComponent(typeof(Collider2D)) as Collider2D).isTrigger = true;

		}
		if (Input.GetKeyUp (press)) {
			(gameObject.GetComponent(typeof(Collider2D)) as Collider2D).isTrigger = false;

		}

	}

}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class YesNoDialogue : MonoBehaviour
{
	//i is what question the player is on
	private int i = 0;
	private string[] questions = {"Do you like the color orange?",
		"Isn't Nickelback the greatest band ever?",
		"Thanksgiving is coming up... how about that stuffing?",
		"Are you having fun in Game Programming?",
		"Archers are cool. Do you like archers?",
		"I changed my mind! Warriors are the way to go. Do you like them better?",
		"Are... are you lying to me?",
		"Are you ready to go on our next adventure?"
	};
	private Text question;

	// Use this for initialization
	void Start () {
		GameObject textObject = GameObject.Find ("Question");
		question = textObject.GetComponent<Text> ();
		question.text = questions [i]; 
	}

	// Update is called once per frame
	void Update () {
		if (i == questions.Length) {
			question.text = "All done!";
		}
	}

	public void OnPostiveClick () {
		i++;
		question.text = "Great! Also, " + questions [i];
		Debug.Log ("Increase RP by 1");

	}

	public void OnNegativeClick () {

		i++;
		question.text = "Disgusting! Also, " + questions [i]; 
		Debug.Log ("Decrease RP by 1");

	}


}


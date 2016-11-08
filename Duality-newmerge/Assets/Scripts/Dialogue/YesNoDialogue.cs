using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class YesNoDialogue : MonoBehaviour
{
	//i is what question the player is on
	private int i = 0;
	private string[] questions = {"Do you like the color orange?",
		"Do you like this game?",
		"Thanksgiving is coming up... do you think Bush did 9/11?",
		"Are you having fun in Game Programming?",
		"Would you kill someone for an A?",
		"Would you kill someone for an A in Game Programming?"
	};
	private Text question;
	private Button button;

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

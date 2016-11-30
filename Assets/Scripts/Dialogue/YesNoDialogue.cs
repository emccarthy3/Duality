using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class YesNoDialogue : MonoBehaviour 
{
	private GameObject gc;
	private GameController gameController;
	[SerializeField] private Button endButton;
	//i is what question the player is on
	private int i = 0;
	private const int MIN_RP = 1;
	private const int MAX_RP = 10;
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
	private Dictionary<string[], int> buttons;

	// Use this for initialization
	void Start() {
		gc = GameObject.Find ("GameController");
		gameController= gc.GetComponent <GameController> ();
		buttons = new Dictionary<string[], int> ();
		buttons.Add (new string[]{"YesButton","Disgusting! Also,"}, 1);
		buttons.Add (new string[]{"NoButton","Great! Also,"}, -1);
		endButton.gameObject.SetActive (false);
		GameObject textObject = GameObject.Find ("Question");
		question = textObject.GetComponent<Text> ();
		question.text = questions [i]; 
	}

	// Update is called once per frame
	void Update () {
		if (i == questions.Length) {
			question.text = "All done!";
			endButton.gameObject.SetActive (true);
		}
	}
/*	public void OnClick(){
		i++;
		GameController.player.RP += buttons [EventSystem.current.currentSelectedGameObject.name];

	}
	*/
	public void OnPostiveClick () {
		i++;
		question.text = "Great! Also, " + questions [i];
		if (gameController.YourPlayer.RP < MAX_RP) {
			gameController.YourPlayer.RP += 1;
			gameController.YourPartner.RP += 1;
		}
	}

	public void OnNegativeClick () {
		i++;
		question.text = "Disgusting! Also, " + questions [i]; 
		if (gameController.YourPlayer.RP > MIN_RP) {
			gameController.YourPlayer.RP -= 1;
			gameController.YourPartner.RP -= 1;
		}

	}
	public void SwitchScenes(){
		SceneManager.LoadScene ("newBattle");
	}

}


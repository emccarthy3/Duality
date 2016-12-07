using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class YesNoDialogue : State
{
	private GameObject gc;
	private GameController gameController;
	[SerializeField] private Button firstButton;
	[SerializeField] private Button secondButton;
	[SerializeField] private Button endButton;
	//i is what question index the player is on
	private int i = 0;
	private const int MIN_RP = 1;
	private const int MAX_RP = 10;
	//change so it has to do with personality type, not class

	Dictionary<int, Dialogue> d;

	private Dialogue dialogue;

	private string[] warriorQuestions = {"Hey I'm Morty the Magician",
		"I enjoy the 'hood' life, how about you?",
		"By the way, I brought some snacks.  Want some?",
		"Huh? What's that over there? Is it an enemy?",
		"Come on, let's take them on!!",
	};
	private string[] warrior2Questions = {"Wow that was a tough battle",
		"I enjoy the 'hood' life, how about you?",
		"By the way, I brought some snacks.  Want some?",
		"Huh? What's that over there? Is it an enemy?",
		"Come on, let's take them on!!",
	};
	private string[] warrior3Questions = {"Hey I'm Morty the Magician",
		"I enjoy the 'hood' life, how about you?",
		"By the way, I brought some snacks.  Want some?",
		"Huh? What's that over there? Is it an enemy?",
		"Come on, let's take them on!!",
	};
	private string[] rangerQuestions = {"Do you like the color orange?",
		"Isn't Nickelback the greatest band ever?",
		"Thanksgiving is coming up... how about that stuffing?",
		"Are you having fun in Game Programming?",
		"Are you ready to go on our next adventure?"
	};
	private string[] ranger2Questions = {"How about that battle though?",
		"Isn't Nickelback the greatest band ever?",
		"Thanksgiving is coming up... how about that stuffing?",
		"Are you having fun in Game Programming?",
		"Are you ready to go on our next adventure?"
	};
	private string[] ranger3Questions = {"Do you like the color orange?",
		"Isn't Nickelback the greatest band ever?",
		"Thanksgiving is coming up... how about that stuffing?",
		"Are you having fun in Game Programming?",
		"Are you ready to go on our next adventure?"
	};
	private string[] magicianQuestions = {"Hello! Are you from around here?",
		"Were you also sent by the King and Queen to go on the mission?",
		"Have you fought before?",
		"Maybe you can show me the ropes? I've only practiced my magic on dummies.",
		"Oh yeah, I forgot to mention I'm a Magician. You don't have a problem with that, do you?",
	};
	private string[] magician2Questions = {"Wow, what a spectacle!",
		"Were you also sent by the King and Queen to go on the mission?",
		"Have you fought before?",
		"Maybe you can show me the ropes? I've only practiced my magic on dummies.",
		"Oh yeah, I forgot to mention I'm a Magician. You don't have a problem with that, do you?",
	};
	private string[] magician3Questions = {"Hello! Are you from around here?",
		"Were you also sent by the King and Queen to go on the mission?",
		"Have you fought before?",
		"Maybe you can show me the ropes? I've only practiced my magic on dummies.",
		"Oh yeah, I forgot to mention I'm a Magician. You don't have a problem with that, do you?",
	};
	public void InitializeDictionary() {
		d.Add(1, new Dialogue(warriorQuestions, new string[]{"Cool Robe bro", "Not my scene", "Yeah, I'm hungry", "I want to go home..", "Yeah!"}, new string[]{"What happened to your face?", "Totally", "I don't trust you", "Let's take them on", "Fine..."}, new bool[]{true, false, true, false, true}));
		d.Add(2, new Dialogue(rangerQuestions, new string[]{"yes", "no", "yes", "yes", "no"}, new string[]{"no", "yes", "no", "no", "yeah!"}, new bool[]{true, false, true, false, true}));
		d.Add(3, new Dialogue(magicianQuestions, new string[]{"yes", "no", "yes", "yes", "no"}, new string[]{"no", "yes", "no", "no", "yeah!"}, new bool[]{true, false, true, false, true}));
		d.Add(4, new Dialogue(warrior2Questions, new string[]{"Cool Robe bro", "Not my scene", "Yeah, I'm hungry", "I want to go home..", "Yeah!"}, new string[]{"What happened to your face?", "Totally", "I don't trust you", "Let's take them on", "Fine..."}, new bool[]{true, false, true, false, true}));
		d.Add(5, new Dialogue(ranger2Questions, new string[]{"yes", "no", "yes", "yes", "no"}, new string[]{"no", "yes", "no", "no", "yeah!"}, new bool[]{true, false, true, false, true}));
		d.Add(6, new Dialogue(magician2Questions, new string[]{"yes", "no", "yes", "yes", "no"}, new string[]{"no", "yes", "no", "no", "yeah!"}, new bool[]{true, false, true, false, true}));
		d.Add(7, new Dialogue(warrior3Questions, new string[]{"Cool Robe bro", "Not my scene", "Yeah, I'm hungry", "I want to go home..", "Yeah!"}, new string[]{"What happened to your face?", "Totally", "I don't trust you", "Let's take them on", "Fine..."}, new bool[]{true, false, true, false, true}));
		d.Add(8, new Dialogue(ranger3Questions, new string[]{"yes", "no", "yes", "yes", "no"}, new string[]{"no", "yes", "no", "no", "yeah!"}, new bool[]{true, false, true, false, true}));
		d.Add(9, new Dialogue(magician3Questions, new string[]{"yes", "no", "yes", "yes", "no"}, new string[]{"no", "yes", "no", "no", "yeah!"}, new bool[]{true, false, true, false, true}));
	}

	private Text question;
	private Dictionary<string[], int> buttons;
	private Text firstButtonText;
	private Text secondButtonText;

	// Use this for initialization
	public override void Start() {
		d = new Dictionary<int, Dialogue>();
		InitializeDictionary ();
		i = 0;

		gc = GameObject.Find ("GameController");
		gameController= gc.GetComponent <GameController> ();
		Debug.Log ("Personality Type" + gameController.YourPlayer.PersonalityType);
		GameObject playerSprite = GameObject.Find ("PlayerSprite");
		playerSprite.GetComponent<SpriteRenderer> ().sprite = gameController.YourPlayer.PlayerSprite;
		GameObject partnerSprite = GameObject.Find ("PartnerSprite");
		partnerSprite.GetComponent<SpriteRenderer> ().sprite = gameController.YourPartner.PlayerSprite;
		GameObject background = GameObject.Find ("Background");
		background.GetComponent<SpriteRenderer> ().sprite = gameController.Backgrounds[gameController.BattleLoop];

		endButton.gameObject.SetActive (false);
		GameObject textQuestionObject = GameObject.Find ("Question");
		question = textQuestionObject.GetComponent<Text> ();
		//tests for ally
		//question.text = questions [i];


		GameObject firstButtonTextObject = GameObject.Find ("FirstButtonText");
		firstButtonText = firstButtonTextObject.GetComponent<Text> ();
		GameObject secondButtonTextObject = GameObject.Find ("SecondButtonText");
		secondButtonText = secondButtonTextObject.GetComponent<Text> ();

		dialogue = d [gameController.YourPlayer.PersonalityType];
		Debug.Log ("first dialogue"+dialogue.FirstAnswers[0]);
		firstButton.onClick.AddListener(() =>  OnClick(dialogue.FirstAnswers, true));
		secondButton.onClick.AddListener(() =>  OnClick(dialogue.SecondAnswers, false));

		Iterate ();
	}

	// Update is called once per frame
	public override	void Update () {
		if (i == dialogue.Dialogues.Length) {
			question.text = "All done!";
			endButton.gameObject.SetActive (true);
			firstButton.gameObject.SetActive (false);
			secondButton.gameObject.SetActive (false);
		}
	}

	public void Iterate() {
		Debug.Log("i in iterate" + i);
		question.text = dialogue.Dialogues[i];

		firstButtonText.text = dialogue.FirstAnswers [i];
		secondButtonText.text = dialogue.SecondAnswers [i];

	}

	public void OnClick (string[] answers, bool isGood){
		bool checkIfGood;
		if (isGood) {
			checkIfGood = dialogue.IsGood[i];
		} else {
			checkIfGood = !dialogue.IsGood[i];
		}

		if (checkIfGood) {
			gameController.YourPlayer.RP += 1;
		} else {
			gameController.YourPlayer.RP -= 1;
		}

		i++;
		Iterate ();
	}

	public void SwitchScenes(){
		gameController.YourPlayer.PersonalityType += 3;
		SceneManager.LoadScene ("newBattle");
	}


}


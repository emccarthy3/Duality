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
	[SerializeField] private Image dialogueBubble;
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
	private string[] warrior3Questions = {"I did some dark magic in the last battle, did you notice? >:)",
		"The enemy couldn't see me through my hood!",
		"Haha, I got to teleport off the mountain because I'm good at magic!",
		"Are you ready for the final battle?",
		"We can do this!",
	};
	private string[] rangerQuestions = {"This first enemies we’re going to have to face are in the plains. Do you think you have the skill?",
		"Well, show me what you can do!",
		"Wow…. Practice makes perfect!",
		"Maybe if we think of this battle as a practice round, it’ll be easier for us, and we’ll win!",
		"Alright, are you ready?"
	};
	private string[] ranger2Questions = {"Ha, we breezed through that, didn’t we?",
		"Whoa, let’s just focus on the fact that we made it through!",
		"Next up, we just get to the top of these mountains, and we crush it again!",
		"Before you do, can I ask you something?",
		"Do you think we can really win this for our kingdom?"
	};
	private string[] ranger3Questions = {"Looks like you’re not too bad- for a beginner >:)",
		"Don’t get carried away, we still have a long battle ahead of us.",
		"Look, we’re about to face a great threat. All of our training will come down to this fight...",
		"We’re about to face the King of the Mountains, only the greatest threat to our kingdom! We might not make it out alive! What’re your final thoughts?",
		"Well, that was a waste of final words. Let’s move on!",
	};
	private string[] magicianQuestions = {"Our first opponents are in the plains. What do you think of that",
		"Not the answer that I was expecting.. But that’s okay! Expect the unexpected, right?",
		"If you say so! Is there anything you learned in training that you think will be effective?",
		"Maybe we should just get into it and see how we do.",
		"Try not to die out there.",
	};
	private string[] magician2Questions = {"They didn’t even know what was coming to them!",
		"I’m glad we made it out in one piece!",
		"Crossing the mountain might be hard, but the battle on the other side will be even tougher.",
		"Can I ask you something?",
		"Do you think we can really win this for our kingdom?",
	};
	private string[] magician3Questions = {"Looks like you’re not too bad- for a beginner >:)",
		"Don’t get carried away, we still have a long battle ahead of us.",
		"Look, we’re about to face a great threat. All of our training will come down to this fight...",
		"We’re about to face the King of the Mountains, only the greatest threat to our kingdom! We might not make it out alive! What’re your final thoughts?",
		"Well, that was a waste of final words. Let’s move on!",
	};
	public void InitializeDictionary() {
		d.Add(1, new Dialogue(warriorQuestions, new string[]{"Cool Robe bro", "Not my scene", "Yeah, I'm hungry", "I want to go home..", "Yeah!"}, new string[]{"What happened to your face?", "Totally", "I don't trust you", "Let's take them on", "Fine..."}, new bool[]{true, false, true, false, true}));
		d.Add(2, new Dialogue(rangerQuestions, new string[]{"I’m confident in our abilities!", "(drops weapon)", "You’re right!", "That’s a terrible idea!", "NO"}, new string[]{"We’re going to die out there.", "(does an elaborate twisty move)", "I don’t need practice!","Let's do it!","I was born ready!"}, new bool[]{true, false, true, false, true}));
		d.Add(3, new Dialogue(magicianQuestions, new string[]{"Plains are lovely.", "Dealing with you is going to be just awful.", "(does an elaborate twisty move)", "Smart idea!", "(says nothing)"}, new string[]{"I'm going to crush them on my own", "Especially true in this situation", "(doesn’t move an inch)", "I'll be fine", "You too!"}, new bool[]{true, false, true, true, false}));
		d.Add(4, new Dialogue(warrior2Questions, new string[]{"Cool Robe bro", "Not my scene", "Yeah, I'm hungry", "I want to go home..", "Yeah!"}, new string[]{"What happened to your face?", "Totally", "I don't trust you", "Let's take them on", "Fine..."}, new bool[]{true, false, true, false, true}));
		d.Add(5, new Dialogue(ranger2Questions, new string[]{"We might be unstoppable!", "I don’t know if I can do it again.", "I’m going to train.", "Sure.", "Im unsure"}, new string[]{"I struggled alot", "True! Let’s just make it through again!", "I’m going to rest.", "What??", "Without a doubt!"}, new bool[]{true, false, true, true, false}));
		d.Add(6, new Dialogue(magician2Questions, new string[]{"We did great!", "Now, just to cross this mountain!", "Ugh", "Yeah!", "Absolutely!"}, new string[]{"Yeah, neither did you, apparently.", "I’m exhausted.", "Nothing we can’t handle.", "What do you want this time?", "*walks away*"}, new bool[]{true, true, false, true, true}));
		d.Add(7, new Dialogue(warrior3Questions, new string[]{"I was mesmerized", "The hood still isn't cool..", "Why didn't you take me?", "I want to go home..", "Yeah!"}, new string[]{"Lameee....", "Cool!", "I'm jealous!", "Let's take them on", "I guess.."}, new bool[]{true, false, false, false, true}));
		d.Add(8, new Dialogue(ranger3Questions, new string[]{"Being a softy?", "Thou beith a softy.", "I can take on anyone!", "Don’t let your memes be dreams.", "Wait, what?"}, new string[]{"Thanks!", "Really? I could use a rest...", "Who’re we facing, anyways?", "Dolla dolla bill y’all.", "Charge!"}, new bool[]{false, true, false, true, false}));
		d.Add(9, new Dialogue(magician3Questions, new string[]{"Being a softy?", "Thou beith a softy.", "I can take on anyone!", "Don’t let your memes be dreams.", "Wait, what?"}, new string[]{"Thanks!", "Really? I could use a rest...", "Who’re we facing, anyways?", "Dolla dolla bill y’all.", "Charge!"}, new bool[]{false, true, false, true, false}));
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
			dialogueBubble.gameObject.SetActive (false);

			endButton.gameObject.SetActive (true);
			firstButton.gameObject.SetActive (false);
			secondButton.gameObject.SetActive (false);
		}
	}

	//makes the text autotype out to mimic speaking/create better flow of the game.  Source: http://wiki.unity3d.com/index.php?title=AutoType
	IEnumerator TypeText (string dialogueText) {
		float letterPause = 0.02f;
		question.text = "";
		firstButton.gameObject.SetActive (false);
		secondButton.gameObject.SetActive (false);
		foreach (char letter in dialogueText.ToCharArray()) {
			question.text += letter;
			//if (sound)
			//	audio.PlayOneShot (sound);
			yield return 0;
			yield return new WaitForSeconds (letterPause);
		} 
		firstButton.gameObject.SetActive (true);
		secondButton.gameObject.SetActive (true);
		firstButtonText.text = dialogue.FirstAnswers [i];
		secondButtonText.text = dialogue.SecondAnswers [i];
	}
	public void Iterate() {
		Debug.Log("i in iterate" + i);
		//question.text = dialogue.Dialogues[i];
		StartCoroutine(TypeText(dialogue.Dialogues[i]));


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


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
using System.Linq;
public class YesNoDialogue : MonoBehaviour
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

	Dictionary<int, List<string>> d;

	private Dialogue dialogue;
	private string[] warriorQuestions = {"Greetings, I'm Morty the Magician and I'm here to mesmerize you", "Fuck off m8", "Let's see it!", "Well aren't you a ray of happy fucking sunshine", "Get ready for my lazor!" };

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
		d.Add(1,new List<string>(new string[]{"Greetings, I'm Morty the Magician and I'm here to mesmerize you","Fuck off m8", "Let's see it!","Well aren't you a ray of happy fucking sunshine","Taddaaa!! (Morty made a frog appear. What do you have to say?","the brightest ray there is","Sorry m8 I forgot my mountain dew","WOW", "6.5/10","Woah is that an enemy over there?","lol fuck off", "fine"}));
		/*d.Add(2, new Dialogue(rangerQuestions, new string[]{"I’m confident in our abilities!", "(drops weapon)", "You’re right!", "That’s a terrible idea!", "NO"}, new string[]{"We’re going to die out there.", "(does an elaborate twisty move)", "I don’t need practice!","Let's do it!","I was born ready!"}, new bool[]{true, false, true, false, true}));
		d.Add(3, new Dialogue(magicianQuestions, new string[]{"Plains are lovely.", "Dealing with you is going to be just awful.", "(does an elaborate twisty move)", "Smart idea!", "(says nothing)"}, new string[]{"I'm going to crush them on my own", "Especially true in this situation", "(doesn’t move an inch)", "I'll be fine", "You too!"}, new bool[]{true, false, true, true, false}));
		d.Add(4, new Dialogue(warrior2Questions, new string[]{"Cool Robe bro", "Not my scene", "Yeah, I'm hungry", "I want to go home..", "Yeah!"}, new string[]{"What happened to your face?", "Totally", "I don't trust you", "Let's take them on", "Fine..."}, new bool[]{true, false, true, false, true}));
		d.Add(5, new Dialogue(ranger2Questions, new string[]{"We might be unstoppable!", "I don’t know if I can do it again.", "I’m going to train.", "Sure.", "Im unsure"}, new string[]{"I struggled alot", "True! Let’s just make it through again!", "I’m going to rest.", "What??", "Without a doubt!"}, new bool[]{true, false, true, true, false}));
		d.Add(6, new Dialogue(magician2Questions, new string[]{"We did great!", "Now, just to cross this mountain!", "Ugh", "Yeah!", "Absolutely!"}, new string[]{"Yeah, neither did you, apparently.", "I’m exhausted.", "Nothing we can’t handle.", "What do you want this time?", "*walks away*"}, new bool[]{true, true, false, true, true}));
		d.Add(7, new Dialogue(warrior3Questions, new string[]{"I was mesmerized", "The hood still isn't cool..", "Why didn't you take me?", "I want to go home..", "Yeah!"}, new string[]{"Lameee....", "Cool!", "I'm jealous!", "Let's take them on", "I guess.."}, new bool[]{true, false, false, false, true}));
		d.Add(8, new Dialogue(ranger3Questions, new string[]{"Being a softy?", "Thou beith a softy.", "I can take on anyone!", "Don’t let your memes be dreams.", "Wait, what?"}, new string[]{"Thanks!", "Really? I could use a rest...", "Who’re we facing, anyways?", "Dolla dolla bill y’all.", "Charge!"}, new bool[]{false, true, false, true, false}));
		d.Add(9, new Dialogue(magician3Questions, new string[]{"Being a softy?", "Thou beith a softy.", "I can take on anyone!", "Don’t let your memes be dreams.", "Wait, what?"}, new string[]{"Thanks!", "Really? I could use a rest...", "Who’re we facing, anyways?", "Dolla dolla bill y’all.", "Charge!"}, new bool[]{false, true, false, true, false}));
		*/
	}

	private Text question;
	private Dictionary<string[], int> buttons;
	private Dictionary<int, int[]> dialoguePaths;
	private Text firstButtonText;
	private Text secondButtonText;
	private string answer1;
	private string answer2;
	private List<string> dialogueList;
	private int[] responseIndexes;
	private Dialogue prevDialogue;
	private Dialogue currentDialogue;
	// Use this for initialization
	 void Start() {
		d = new Dictionary<int, List<string>>();
		InitializeDictionary ();
		dialoguePaths = new Dictionary<int, int[]> ();
		InitializeDialogPaths ();
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
		GameObject firstButtonTextObject = GameObject.Find ("FirstButtonText");
		firstButtonText = firstButtonTextObject.GetComponent<Text> ();
		GameObject secondButtonTextObject = GameObject.Find ("SecondButtonText");
		secondButtonText = secondButtonTextObject.GetComponent<Text> ();
		dialogueList = d [gameController.YourPlayer.PersonalityType];
		prevDialogue = new Dialogue (dialogueList[0]);
		SetNextDialogue (prevDialogue);
		firstButton.onClick.AddListener (() => {i++;currentDialogue = new Dialogue (prevDialogue.DialogueDictionary[firstButtonText.text].DialogueString); SetNextDialogue(currentDialogue);});
		secondButton.onClick.AddListener (() => {i++;currentDialogue = new Dialogue (prevDialogue.DialogueDictionary[secondButtonText.text].DialogueString); SetNextDialogue(currentDialogue);});
	}
	//provides implementation for how the dialog answers are mapped to the questions.
	public void InitializeDialogPaths(){
		dialoguePaths.Add(0,new int[]{1,3,2,4,0});
		dialoguePaths.Add(3,new int[]{5,9,6,9,-1});
		dialoguePaths.Add (4, new int[]{ 7, 9, 8, 9,1});
		dialoguePaths.Add (9, new int[]{ 10, 10, 11, 11,0});

	}
	// Update is called once per frame
	void Update () {
		//change this to a constant for how big the tree is
		if (i == 3) {
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
			yield return 0;
			yield return new WaitForSeconds (letterPause);
		} 
		firstButton.gameObject.SetActive (true);
		secondButton.gameObject.SetActive (true);

		firstButtonText.text = prevDialogue.DialogueDictionary.Keys.First();
		secondButtonText.text = prevDialogue.DialogueDictionary.Keys.Last();
	}

	public void SetNextDialogue(Dialogue dialogue){
		responseIndexes = dialoguePaths [dialogueList.IndexOf (dialogue.DialogueString)];
		dialogue.DialogueDictionary.Add (dialogueList[responseIndexes[0]], new Dialogue(dialogueList[responseIndexes[1]]));
		dialogue.DialogueDictionary.Add (dialogueList[responseIndexes[2]],new Dialogue(dialogueList[responseIndexes[3]]));
		prevDialogue = dialogue;
		gameController.YourPlayer.RP += responseIndexes [4];
		StartCoroutine(TypeText(dialogue.DialogueString));
	}

	public void SwitchScenes(){
		gameController.YourPlayer.PersonalityType += 3;
		SceneManager.LoadScene ("newBattle");
	}


}


using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System.Linq;

public class YesNoDialogue : AbstractDialogue {
	private GameObject gc;
	private GameController gameController;
	[SerializeField] private Button firstButton;
	[SerializeField] private Button secondButton;
	[SerializeField] private Button endButton;
	[SerializeField] private Image dialogueBubble;
	//i is what question index the player is on
	private int index;
	private const int MIN_RP = 1;
	private const int MAX_RP = 10;
	private const int SWITCH_DIALOGUE_NUMBER = 3;
	private const int DIALOGUE_TREE_SIZE = 5;
	private const float TYPE_TEXT_DELAY = .00000002f;
	//change so it has to do with personality type, not class

	Dictionary<int, List<string>> dialogueDictionary;

	private Dialogue dialogue;

	//Initializes dialogues.  The 
	public void InitializeDictionary() {
		dialogueDictionary.Add(1,new List<string>(new string[]{"Greetings, naive one. I see you’ll be my partner for our quest.", "Cool story, bro.", "Nice dude!", "Ah, I see, a typical nitwit warrior. I foresaw this happening. How could the King choose a buffoon like you?", "Yes, indeed, ‘Dude’. Allow me to introduce myself. I’m Morty. Morty the Mage! I’m eager to go alongside you on this epic quest.", "Who’re you calling a nitwit?", "I’m not a baboon…", "Woah, epic?!", "(Stare blankly at Morty)", "You! If you aren’t already aware, the King wants us to go on a perilous quest to conquer the other four kingdoms of the land. You’ve got to have brains and brawn to survive!", "Let me make this easy for you… King tell us to fight bad men and win kingdoms. Need smart to fight bad men. You need more smart and strength.",  "Indeed. Conquering all the kingdoms in the land will be quite ‘epic’. How much combat experience do you have, anyway?", "You… you are aware of the scale of our quest, right? We’re traveling across the land to conquer the other four kingdoms in the name of the King! Are you even prepared for battle?", "I’ve got brains, I read a book once...", "Already there (flexes)", "WE WIN KINGDOMS!", "ME SMASH BAD MEN!!!", "Does this answer your question (flexes arms)?", "(Does elaborate move with weapon)", "Psh. I was born ready to battle.", "I mean, sure, whatever.", "Great, that’s the spirit. With you on my team, let’s hope we don’t die on day one...", "Excellent. Well we can only hope you prove me wrong and be a valuable asset. Teamwork’s the only way we’ll make good progress on this journey.", "Sure, like I’m the weakest one...", "I’m too sexy and strong to die!", "Teamwork makes the dreamwork, bro!", "I’ll do my best, dude!", "Wait, what’s that on the horizon? Looks like that group is heading right for us!", "Where? I don’t see them!", "CHARGE!!"}));
		dialogueDictionary.Add(4,new List<string>(new string[]{"Huff, can you believe how long it’s been since our first battle? Look at all we’ve accomplished since then.", "Huh?", "Amazing, dude.", "Well, think about it. So far we’ve conquered the Kingdom of the Plains, the Desert Kingdom, and the Kingdom by the Ocean. It’s remarkable how we’ve conquered them all and yet no word from the King…", "You said it! We’ve travelled across the mighty planes, the perilous desert, and the great stretches of sea, and we haven’t had a single setback yet! Interesting that we haven’t heard back from the King after all we’ve been through.", "And?", "Ooh! A butterfly!", "That’s odd.", "Probably nothing!", "We’ve already done so much! Come on, something’s not right. The auras seem pretty imbalanced. Obviously the king wouldn’t do us any harm, but why would he not send us some response.", "Focus! Now’s not the time for goofing around! You don’t want to fall off and die on this mountain just because you were catching a stupid butterfly?.",  "Indeed. Come to think of it, we’ve sent out so many messages to the King. They should’ve responded by now. Hopefully nothing’s wrong back at home...", "I don’t know if I’d go that far. Think about it- we’ve been out here for weeks now fighting for the King, conquering the other kingdoms for the King, and for what? For him to give us no feedback or response or any word? Very bizarre if you ask me.", "Maybe your auras are wrong? It’s the King!", "Good point!", "Hey! It was a pretty butterfly!", "Sorry...", "What could’ve happened?", "I’m nervous!", "He’s probably just busy!", "Now that you mention it, that IS bizarre.", "Anyways, that’s now the least of our concerns. We’re getting closer to the Mountain Kingdom, the fiercest kingdom yet! Time to put our troubles aside and win this for the King!", "Well, that’s something we can focus on later. Now we’re approaching the mighty Mountain Kingdom! Are you ready to take them on?", "For the King!", "ROAR!!!", "Let’s do this!", "I WAS BORN READY!!", "Come on now!! I see two enemies ahead! Get your weapons ready!", "Wait! Let met tie my shoes!", "RIGHT! (twirls weapon, drops weapon)"}));
		dialogueDictionary.Add(7,new List<string>(new string[]{"Hooray! We’re finally done with our journey! We conquered the four kingdoms!", "Cool beans.", "Niceee!", "Cool beans? That’s it? We’ve travelled across the world, fought our way across the four kingdoms, been together through thick and thin and all you have to say to that is ‘Cool beans’???", "Nice indeed, ‘Bro’, nice indeed. The king will be so pleased with how much we’ve accomplished! Speaking of which, still no word from him and we’re almost home... now I’m concerned.", "Pretty much. ", "Heh... beans...", "Same here, I wonder what’s wrong.", "But we’ve already finished our quest!", "Well, can’t ask for much more. After all, whether the beans are cool is not our main concern. We still haven’t heard back from the King and we’re almost home! I wonder what this means?", "I can’t believe this. HOW?? HOW DID YOU MAKE IT THIS FAR YOU BUMBLING IDIOT! Now we have two problems to deal with...", "So we went through all of the kingdoms, we conquered them all, and no response from the king? What was the point of this journey if the King is going to disregard our efforts? I feel completely used.", "A fair point, young ward. However, the King has given us no response, and what’s the point of our quest if we don’t know the consequences of our actions? We’re running around like mindless servants!", "Eh, I’m not worried.", "Relax, dude!", "Two problems?", "Ya lost me.", "We should fight back!", "Maybe we should talk to the King?", "Easy there! Let’s just talk to him!", "Let’s fight the King on it!", "No, we have to do this… We’re going to confront the King. Too much chaos has ensued for what has seemed like nothing! We’ll stage a rebellion to get the recognition we deserve for our battles!", "You’re right. We have to do this. We’re going to confront the King. Too much chaos has ensued for what has seemed like nothing! We’ll stage a rebellion to get the recognition we deserve for our battles!", "To hell with him!", "He can get some of this! (flexes)", "Down with the King!", "Let’s fight for what’s right!!", "I see his two bodyguards now! We’ll take them on and we’ll show them a thing or two about taking advantage of us! LET’S FIGHT!!", "YEAH!!!!", "Cool beans!"}));
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
	 public override void Start() {
		dialogueDictionary = new Dictionary<int, List<string>>();
		InitializeDictionary ();
		dialoguePaths = new Dictionary<int, int[]> ();
		InitializeDialoguePaths ();
		index = 0;
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
		dialogueList = dialogueDictionary [gameController.YourPlayer.PersonalityType];
		prevDialogue = new Dialogue (dialogueList[index]);
		SetNextDialogue (prevDialogue);
		firstButton.onClick.AddListener (() => {index++;currentDialogue = new Dialogue (prevDialogue.DialogueDictionary[firstButtonText.text].DialogueString); SetNextDialogue(currentDialogue);});
		secondButton.onClick.AddListener (() => {index++;currentDialogue = new Dialogue (prevDialogue.DialogueDictionary[secondButtonText.text].DialogueString); SetNextDialogue(currentDialogue);});
	}

	// Update is called once per frame
	public override void Update () {
		if (index == DIALOGUE_TREE_SIZE) {
			dialogueBubble.gameObject.SetActive (false);
			endButton.gameObject.SetActive (true);
			firstButton.gameObject.SetActive (false);
			secondButton.gameObject.SetActive (false);
		}
	}

	//provides implementation for how the dialogue answers are mapped to the questions.
	public override void InitializeDialoguePaths(){
		dialoguePaths.Add(0,new int[]{1,3,2,4,0});
		dialoguePaths.Add(3,new int[]{5,9,6,10,-1});
		dialoguePaths.Add (4, new int[]{ 7, 11, 8, 12,1});
		dialoguePaths.Add (9, new int[]{ 13, 21, 14, 21, 1});
		dialoguePaths.Add (10, new int[]{ 15, 21, 16, 21, -1 });
		dialoguePaths.Add (11, new int[]{ 17, 22, 18, 22, 1 });
		dialoguePaths.Add (12, new int[]{ 19, 22, 20, 22, -1 });
		dialoguePaths.Add (21, new int[]{ 23, 27, 24, 27, 0 });
		dialoguePaths.Add (22, new int[]{ 25, 27, 26, 27, 0 });
		dialoguePaths.Add (27, new int[]{ 28, 27, 29, 27, 0 });
	}

	//this method takes dialogue list and maps indices to questions/responses (i.e. responseIndexes[0] response will trigger a new dialogue with responseIndexes[1])
	public override void SetNextDialogue(Dialogue dialogue){
		if (index < DIALOGUE_TREE_SIZE) {
			responseIndexes = dialoguePaths [dialogueList.IndexOf (dialogue.DialogueString)];
			dialogue.DialogueDictionary.Add (dialogueList [responseIndexes [0]], new Dialogue (dialogueList [responseIndexes [1]]));
			dialogue.DialogueDictionary.Add (dialogueList [responseIndexes [2]], new Dialogue (dialogueList [responseIndexes [3]]));
			prevDialogue = dialogue;
			gameController.YourPlayer.RP += responseIndexes [4];
			StartCoroutine (TypeText (dialogue.DialogueString));
		}
	}

	//makes the text autotype out to mimic speaking/create better flow of the game.  Source: http://wiki.unity3d.com/index.php?title=AutoType
	public IEnumerator TypeText (string dialogueText) {
		float letterPause = TYPE_TEXT_DELAY;
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

	public void SwitchScenes(){
		gameController.YourPlayer.PersonalityType += SWITCH_DIALOGUE_NUMBER;
		SceneManager.LoadScene ("newBattle");
	}


}


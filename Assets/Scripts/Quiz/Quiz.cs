using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class Quiz : State {
	private GameObject gc;
	private GameController gameController;
	[SerializeField] private Button endButton;
	//i is what question the player is on
	private int i = 0;
	private string[] questions = {"People would say that I’m the life of the party!", 
		"If I saw a bank robbery, I would chase after the robbers and help bring them to justice.", 
		"I prefer to go out to a party or bar than stay in on a Saturday night.", 
		"I love venturing out into the great outdoors!", 
		"I have many friends from all over rather than one small, tight-knit group of close friends.", 
		"The end goal in life is to be successful, not to be happy.", 
		"I’m known as the thrill-seeker amongst my friends.", 
		"I would not consider myself to be religious or spiritual.", 
		"I get by with a little help from my friends.", 
		"People would say that I’m a stubborn individual.", 
		"I don’t care if hurt somebody’s feelings… if they’re wrong, I’m going to call them out for it.",
		"I’m not really a day-dreamer, I’m much more down to earth.", 
		"I would rather be in business and make lots of money than be an artist.",
		"My best friend just cheated off of my test and got an A… I can’t risk them getting suspended, so I guess I’ll pretend I didn’t know.",
		"You can probably find me playing a game of chess rather than watching."
	};
	private Text question;
	private bool isFinished;
	Dictionary<string, int> buttons = new Dictionary<string, int>();
	//
	private double score = 0;

	// Use this for initialization
	public override void Start() {
		gc = GameObject.Find ("GameController");
		gameController= gc.GetComponent <GameController> ();
		Debug.Log ("starting up quiz");
		buttons.Add("QuizFighterButton", 3);
		buttons.Add("QuizArcherButton", 2);
		buttons.Add("QuizWizardButton", 1);
		endButton.gameObject.SetActive (false);
		isFinished = false;
		//loads the question to the panel
		GameObject textObject = GameObject.Find ("QuizQuestion");
		question = textObject.GetComponent<Text> ();
		endButton.onClick.AddListener(() =>  gameController.SwitchScene("Dialogue1"));
		question.text = questions [i]; 
	}

	// Update is called once per frame
	public override void Update () {
		//if the quiz has gone through all of the questions in the questions array
		if (i == questions.Length) {
			//averages the score to determine what class the player is
			double average = score / questions.Length;
			if (average >= 2.5) {
				gameController.YourPlayer = new Player(new Warrior());
				gameController.YourPartner = new Ally (new Magician ());
				question.text = "Congratulations! You are a warrior!";

			} else if (average >= 1.5 && average < 2.5) {
				question.text = "Congratulations! You are an ranger!";
				gameController.YourPlayer= new Player(new Ranger());
				gameController.YourPartner = new Ally (new Warrior ());
			} else {
				question.text = "Congratulations! You are a magician!";
				gameController.YourPlayer = new Player(new Magician());
				gameController.YourPartner = new Ally (new Ranger ());
			}
			endButton.gameObject.SetActive (true);
		}
	}
    public void OnClick () {   
		score += buttons [EventSystem.current.currentSelectedGameObject.name];
		Debug.Log ("current score" + score);
		i++;
		question.text = questions [i];
        }

	public bool IsFinished{
		get{ return isFinished; }
		set{ isFinished = value; }
	}

}

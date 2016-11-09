using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Quiz : MonoBehaviour {
	[SerializeField] private Button endButton;
	//i is what question the player is on
	private int i = 0;
	private string[] questions = {"Do you like to gamble?",
		"Do you believe in fate?",
		"Thanksgiving is coming up... how about that stuffing?",
		"Would you consider yourself to be religious or spiritual?",
		"What is your opinion on cinnamon rolls?",
		"Do you prefer action movies over fantasy/sci-fi?",
		"Are... are you lying to me?",
		"Do you prefer travelling for vacation over staying at home?"
	};
	private Text question;
	private bool isFinished;
	//
	private double score = 0;

	// Use this for initialization
	void Start() {
		endButton.gameObject.SetActive (false);
		isFinished = false;
		//loads the question to the panel
		GameObject textObject = GameObject.Find ("QuizQuestion");
		question = textObject.GetComponent<Text> ();
		question.text = questions [i]; 
	}

	// Update is called once per frame
	void Update () {
		//if the quiz has gone through all of the questions in the questions array
		if (i == questions.Length) {
			//averages the score to determine what class the player is
			double average = score / questions.Length;
			if (average >= 2.5) {
				question.text = "Congratulations! You are a fighter!";
			} else if (average >= 1.5 && average < 2.5) {
				question.text = "Congratulations! You are an archer!";
			} else {
				question.text = "Congratulations! You are a wizard!";
			}
			endButton.gameObject.SetActive (true);
		}
	}

	public void OnWarriorClick () {
		score += 3;
		i++;
		question.text = questions [i];
		Debug.Log ("Increase score by 3");

	}

	public void OnRangerClick () {
		score += 2;
		i++;
		question.text = questions [i]; 
		Debug.Log ("Increase score by 2");

	}

	public void OnMagicianClick () {
		score += 1;
		i++;
		question.text = questions [i]; 
		Debug.Log ("Increase score by 1");

	}
	public bool IsFinished{
		get{ return isFinished; }
		set{ isFinished = value; }
	}
	public void SwitchScenes(){
		SceneManager.LoadScene ("Dialogue1");
	}
}

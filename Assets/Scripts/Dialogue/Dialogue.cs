using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue {

	// for first constructor
	private string[] dialogues;
	private string[] firstAnswers;
	private string[] secondAnswers;
	private bool[] isGood;
	// iterator
	private int i = 0;


	// for second constructor
	private string dialogueString;
	private string firstAnswer;
	private string secondAnswer;

	public Dialogue (string[] dialogues, string[] firstAnswers, string[] secondAnswers, bool[] isGood) {
		this.dialogues = dialogues;
		this.firstAnswers = firstAnswers;
		this.secondAnswers = secondAnswers;
		this.isGood = isGood;
	}

	public string[] Dialogues {
		get{ return dialogues; }
		set{ dialogues = value; }
	}

	public string[] FirstAnswers {
		get{ return firstAnswers; }
		set{ firstAnswers = value; }
	}

	public string[] SecondAnswers {
		get{ return secondAnswers; }
		set{ secondAnswers = value; }
	}

	public bool[] IsGood {
		get{ return isGood; }
		set{ isGood = value; }
	}

	private Dictionary<string, Dialogue> dialogueDictionary = new Dictionary<string, Dialogue> ();

	public Dialogue (string dialogueString) {
		this.dialogueString = dialogueString;
	}

	public string DialogueString {
		get{ return dialogueString; }
		set{ dialogueString = value; }
	}

	public string SecondAnswer {
		get{ return secondAnswer; }
		set{ secondAnswer = value; }
	}

	public Dictionary<string, Dialogue> DialogueDictionary {
		get{ return dialogueDictionary; }
		set{ dialogueDictionary = value; }
	}


}
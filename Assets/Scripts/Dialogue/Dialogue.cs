using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue {

	private string[] dialogues;
	private string[] firstAnswers;
	private string[] secondAnswers;
	private bool[] isGood;
	// iterator
	private int i = 0;

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

}
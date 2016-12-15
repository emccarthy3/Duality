using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue {

	private string dialogueString;
	private Dictionary<string, Dialogue> dialogueDictionary = new Dictionary<string, Dialogue> ();

	public Dialogue (string dialogueString) {
		this.dialogueString = dialogueString;
	}

	public string DialogueString {
		get{ return dialogueString; }
		set{ dialogueString = value; }
	}
		

	public Dictionary<string, Dialogue> DialogueDictionary {
		get{ return dialogueDictionary; }
		set{ dialogueDictionary = value; }
	}


}
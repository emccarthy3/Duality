using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractRhythmGame : MonoBehaviour {
	private int score;

	// Use this for initialization
	public abstract void Start ();
	
	// Update is called once per frame
	public abstract void Update ();

	//this method is used to generate the notes when the rhythm game has started
	public abstract IEnumerator MakeNotes();

	public abstract void StartRhythmGame();

	public int Score {
		get{return score;}
		set{ score = value; }
	}
}

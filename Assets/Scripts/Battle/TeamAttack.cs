using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TeamAttack : Action{
	private int baseDamage;
	private string name;
	private NoteScript notes;
	//public RhythmController other;
	private RhythmController x;
	//private Canvas canvas;



	public TeamAttack(string name, int baseDamage){
		Name = name;
		BaseDamage = BaseDamage;
	   // x =GameObject.Find("RhythmController").GetComponent<RhythmController>();

		notes = new NoteScript ();
	}

	public override void ActionBehavior(){
		//trigger the team ui
		//rhythmbackground
	//	canvas.enabled = false;
		//other.AttackTeam();

	//	RhythmController rc = ;
		x.Work();
		BaseDamage = notes.Score;

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

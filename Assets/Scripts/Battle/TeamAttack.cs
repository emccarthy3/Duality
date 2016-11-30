using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TeamAttack : Action{
	private int baseDamage;
	private string name;
	private NoteScript notes;

	//public RhythmController other;
	//private Canvas canvas;

	public TeamAttack(string name, int baseDamage){
		Name = name;
		BaseDamage = BaseDamage;
		notes = new NoteScript ();
	}

	public override void ActionBehavior(){
		/*GameObject rc = GameObject.Find ("RhythmController");
		RhythmController rhythmController = rc.GetComponent <RhythmController> ();

		GameObject uic = GameObject.Find ("UIController");
		UIController uiController = uic.GetComponent <UIController> ();
		uiController.ChangeCanvasState (false);
		rhythmController.Work();
		*/
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

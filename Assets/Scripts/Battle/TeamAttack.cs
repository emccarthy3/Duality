using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TeamAttack : Action {
	private int baseDamage;
	private string name;

	public TeamAttack(string name, int baseDamage){
		Name = name;
		BaseDamage = BaseDamage;
	}

	public override void ActionBehavior(){
		//trigger the team ui
		SceneManager.LoadScene("RhythmScene2D");

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

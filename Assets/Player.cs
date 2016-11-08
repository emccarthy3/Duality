using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : Character{
	private List<Moves> moves;
	public Player(){
		moves = new List<Moves> ();
		//initialize initial moves list 
		moves.Add(new SingleAttack());
		moves.Add (new TeamAttack ());
		moves.Add (new TeamAttack ());
		moves.Add(new TeamAttack());
		Moves = moves;
		Debug.Log ("Moves!" + Moves);

	}
	public override void Attack (){
		Debug.Log ("player is attacking");
	}

	public void Heal(){
	}
	public void Block (){
	}
	public void Level(){
	}
}